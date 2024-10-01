<template>
  <div class="code row">
    <div class="secret socket" :class="[ getPinColour(this.answer[0] ? this.answer[0].colour : '') ]">?</div>
    <div class="secret socket" :class="[ getPinColour(this.answer[1] ? this.answer[1].colour : '') ]">?</div>
    <div class="secret socket" :class="[ getPinColour(this.answer[2] ? this.answer[2].colour : '') ]">?</div>
    <div class="secret socket" :class="[ getPinColour(this.answer[3] ? this.answer[3].colour : '') ]">?</div>
  </div>
</template>

<script>
import mastermind from '../repositories/mastermind'
import { getPinColour } from '../utils/pins'

export default {
  name: 'HiddenRow',

  props: [
    'id'
  ],

  data() {
    return {
      pins: [],
      answer: []
    }
  },

  computed: {
    allPins () {
      var pins = this.pins.slice();

      while(pins.length < 4) {
        pins.push(null)
      }

      return pins;
    }
  },

  methods: {
    checkStatus() {
      mastermind.getStatus(this.id)
        .then(data => {
          if(data.isWon === true) {
            window.EventBus.$emit('status:won', data.rowsPlayed)

            this.$swal({
              icon: 'success',
              title: 'Je hebt gewonnen!',
              text: 'Goed gedaan! klik op "Herstart" om opneiuw te beginnen.',
              allowOutsideClick: false,
              confirmButtonText: 'Restart',
              heightAuto: false
            }).then(data => {
              if (data.isConfirmed)
                this.$parent.$parent.restart();
            });
          }

          if(data.isWon === false && data.rowsPlayed >= 10) {
            window.EventBus.$emit('status:lost', data.rowsPlayed)
            
            this.$swal({
              icon: 'error',
              title: 'Helaas, je hebt verloren',
              text: 'Geen nood! klik op "Herstart" om opnieuw proberen te winnen',
              allowOutsideClick: false,
              confirmButtonText: 'Restart',
              heightAuto: false
            }).then(data => {
              if (data.isConfirmed)
                this.$parent.$parent.restart();
            });
          } 

          this.answer = data.answer || [];
        })
        .catch(() => {
          this.$swal({
            icon: 'error',
            title: 'Something went wrong',
            text: 'Check your developer console for more information',
            heightAuto: false
          })
        })
    },

    getPinColour(colour) {
      return getPinColour(colour)
    }
  },

  mounted() {
    window.EventBus.$on('field:update', this.checkStatus)
  },

  beforeDestroy() {
    window.EventBus.$off('field:update', this.checkStatus)
  }
}
</script>
