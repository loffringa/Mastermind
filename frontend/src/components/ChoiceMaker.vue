<template>
  <div>
    <div id="options" class="container">
      <button @click="push(0)" class="option black"></button>
      <button @click="push(1)" class="option blue"></button>
      <button @click="push(2)" class="option green"></button>
      <button @click="push(3)" class="option red"></button>
      <button @click="push(4)" class="option yellow"></button>
      <button @click="push(5)" class="option white"></button>
      <button @click="push(5)" class="option purple"></button>
      <button @click="sendTry" class="action">&#10004;</button>
      <button @click="pop()" class="action">&#8672;</button>
    </div>
  </div>
</template>

<script>
import mastermind from '../repositories/mastermind'

export default {
  name: "ChoiceMaker",

  props: [
    'id'
  ],

  data() {
    return {
      pins: [],
    }
  },

  methods: {
    sendTry() {
      if(!this.id) return;

      mastermind
        .doNextTry(this.id, this.allPins().map(Number))
        .then(() => {
          window.EventBus.$emit('field:update')
          this.reset();
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

    reset() {
      this.pins = []
      window.EventBus.$emit('choice:clear')
    },

    push(pin) {
      if(this.pins.length < 4) {
        this.pins.push(pin);
        window.EventBus.$emit('choice:push', pin)
      }
    },

    pop(pin) {
      if(this.pins.length > 0) {
        this.pins.pop(pin)
        window.EventBus.$emit('choice:pop', pin)
      }
    },

    allPins () {
      var pins = this.pins.slice();
      while(pins.length < 4) {
        pins.push(null)
      }
      return pins;
    }
  
  }
}
</script>

