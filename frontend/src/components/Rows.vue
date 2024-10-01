<template>
  <div>
    <div id="guesses">
      
      <!-- Secret -->
      <hidden-row :id="id"></hidden-row>

      <!-- Fill -->
      <div v-for="(emptyR, x) in emptyRows" :key="'_' + x" class="guess">
          <div v-for="i in 4" :key="i" class="socket"></div>
      </div>
      
      <!-- Choice -->
      <choice-row></choice-row>
      
      <!-- Guesses -->
      <div v-for="(row, x) in rows" :key="x" class="guess">
        <div v-for="(pin, p) in row.pins" :key="p" class="socket" :class="[ getPinColour(pin.colour) ]"></div>
      </div>

    </div>
    <div id="hints">

      <!-- Secret -->

      <!-- Fill -->
      <div v-for="(emptyR, x) in emptyRows" :key="'_' + x" class="hint">
        <hints-block></hints-block>
      </div>

      <!-- Choice -->
      <choice-hint></choice-hint>

      <!-- Guesses -->
      <div v-for="(row, x) in rows" :key="x" class="hint">
        <hints-block :hints="row"></hints-block>
      </div>

    </div>
  </div>
</template>

<script>
import HintsBlock from './HintsBlock'
import ChoiceRow from './ChoiceRow'
import ChoiceHint from './ChoiceHint'
import HiddenRow from './HiddenRow'

import mastermind from '../repositories/mastermind'
import { getPinColour } from '../utils/pins'

export default {
  name: "Rows",

  components: {
    HintsBlock,
    ChoiceRow,
    ChoiceHint,
    HiddenRow
  },

  data() {
    return {
      rows: []
    }
  },

  props: [
    'id'
  ],

  computed: {
    emptyRows: function() {
      var rows = this.rows.slice()
      var sum = (10 - rows.length)

      return sum > 0 ? (sum-1) : sum
    }
  },

  methods: {
    updateRows() {
      if(!this.id) return;

      mastermind.getAllPlayedRows(this.id)
        .then(data => {
          this.rows = data;
        })
        .catch((error) => {
          console.log(error);
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
    this.updateRows()

    window.EventBus.$on('field:update', this.updateRows)
  },

  beforeDestroy() {
    window.EventBus.$off('field:update', this.updateRows);
  }
}
</script>

