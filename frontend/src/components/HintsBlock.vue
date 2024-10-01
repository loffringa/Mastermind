<template>
  <div>
    <div class="row">
      <div v-for="(item, k) in result[0]" :key="0 + k" class="js-hint-socket socket" :class="[item]"></div>
    </div>
    <div class="row">
      <div v-for="(item, k) in result[1]" :key="1 + k" class="js-hint-socket socket" :class="[item]"></div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'HintsBlock',

  props: {
    'hints': {
      type: Object,
      default() {
        return {
          score: {
            same: 0,
            sameColour: 0
          }
        }
      }
    }
  },

  computed: {
    'result': function() {
      var results = new Array();

      var countSame = this.hints.score.same;
      var countSameColour = this.hints.score.sameColour;

      for(var i = 0; i < countSame; i++) {
        results.push('black')
      }

      for(var j = 0; j < countSameColour; j++) {
        results.push('almost')
      }

      if (results.length < 4) {
        while (results.length < 4) {
          results.push(null)
        }
      }

      return this.chunkArray(results, 2);
    }
  },

  methods: {
    chunkArray(arr, n){
      var chunkLength = Math.max(arr.length/n ,1);
      var chunks = [];
      for (var i = 0; i < n; i++) {
          if(chunkLength*(i+1)<=arr.length)chunks.push(arr.slice(chunkLength*i, chunkLength*(i+1)));
      }
      return chunks; 
    }
  }
}
</script>
