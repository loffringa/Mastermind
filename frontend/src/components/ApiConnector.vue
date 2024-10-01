<template>
  <div class="connection">
    <button @click="start" id="newGame" class="green primary">Start</button>
    <help></help>
  </div>
</template>

<script>
import api from '../repositories/api'
import Help from './Help.vue';

export default {
  name: 'ApiConnector',
  components: {
    Help
  },

  data() {
    return {
      url: "https://localhost:5001/api/Mastermind"
    }
  },

  methods: {
    start() {
      if(this.url) {
        api.setApiUrl(this.url)
        window.EventBus.$emit('url:set')
      }
    },

    clear() {
      this.url = '';

      api.setApiUrl('')
      window.EventBus.$emit('url:clear')
    }
  },

  mounted() {
    this.url = api.getApiUrl()
  }
}
</script>

<style>
.connection {
  text-align: center;
}

h4 {
  color: #6b4d39;
}

input[type=text] {
  border: none;
  padding: 8px;
  border-radius: 8px;
  width: 400px;
  color: #6b4d39;
  font-weight: bold;
}

input[type=text]::placeholder {
  color: gainsboro
}

</style>
