<template>
  <div v-if="visible" class="hint">
    <hints-block></hints-block>
  </div>
</template>

<script>
import HintsBlock from './HintsBlock'

export default {
  name: 'ChoiceRow',

  components: {
    HintsBlock
  },

  data() {
    return {
      visible: true,
    }
  },

  mounted() {
    window.EventBus.$on('status:lost', () => {
      this.visible = false;
    })
  }
}
</script>
