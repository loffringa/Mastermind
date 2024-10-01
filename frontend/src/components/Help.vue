<template>
  <button @click="help" ref="help" id="help" class="yellow ml-1">Help</button>
</template>

<script>
export default {
  name: "Help",

  methods: {
    help() {
      this.$swal({
        imageUrl: '/rules.jpg',
        heightAuto: false,
        width: '100%'
      });
    },
  },

  mounted() {
    window.EventBus.$on('game:start', this.help);
  }
};
</script>

<style>
.ml-1 {
 margin-left: 1em;
}
</style>