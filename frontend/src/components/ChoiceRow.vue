<template>
  <div v-if="visible" class="guess">
    <div v-for="(pin, p) in allPins" :key="p" class="socket" :class="[ getPinColour(pin) ]"></div>
  </div>
</template>

<script>
import { getPinColour } from '../utils/pins'

export default {
  name: 'ChoiceRow',

  data() {
    return {
      pins: [],
      visible: true,
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
    push(_pin) {
      var pin = parseInt(_pin)
      this.pins.push(pin)
    },

    pop(pin) {
      this.pins.pop(pin)
    },

    clear() {
      this.pins = []
    },

    getPinColour(colour) {
      return getPinColour(colour)
    }
  },

  mounted() {
    window.EventBus.$on('choice:push', this.push)    
    window.EventBus.$on('choice:pop', this.pop)
    window.EventBus.$on('choice:clear', this.clear)

    window.EventBus.$on('status:lost', () => {
      this.visible = false;
    })
  }
}
</script>
