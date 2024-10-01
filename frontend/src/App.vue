<template>
  <div id="app">
    <div class="wrapper">
      <header>
        <h1>Mastermind</h1>
      </header>
      <div class="container">
        <api-connector></api-connector>
        <board></board>
      </div>
      <footer>
        <p><small>Made by <a href="https://github.com/che-ict" target="_blank">HBO-ICT | CHE Ede</a>, inspired by <a href="https://github.com/klomontes" target="_blank">klomontes</a></small></p>
      </footer>
    </div>
  </div>
</template>

<script>
import Board from './components/Board'
import ApiConnector from './components/ApiConnector'

export default {
  name: 'App',
  components: {
    Board,
    ApiConnector
  },
}
</script>

<style>
header {
  padding: 10px !important;
}

header > h1 {
  margin: 0 !important;
  margin-top: 20px !important;
  color: #6b4d39;
}

/* #app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
} */
</style>
