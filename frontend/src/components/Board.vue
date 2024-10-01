<template>
  <div class="board">
    <hr v-if="initialized" />
    <div class="game" v-if="initialized" :key="id">
      <rows :id="id" ref="rows"></rows>
      <choice-maker :id="id" ref="choicemaker"></choice-maker>
    </div>
  </div>
</template>

<script>
import mastermind from "../repositories/mastermind";
import Rows from "./Rows";
import ChoiceMaker from "./ChoiceMaker";

export default {
  name: "Board",

  components: {
    Rows,
    ChoiceMaker,
  },

  data() {
    return {
      id: null,
    };
  },

  computed: {
    initialized() {
      return !!this.id;
    },
  },

  methods: {
    restart() {
      this.startGame();
    },

    startGame() {
      mastermind
        .startNewGame()
        .then((id) => {
          console.log(id);

          window.EventBus.$emit('game:start')
          this.id = id;
        })
        .catch((error) => {
          let title = "Something went wrong";
          let text = "Check your developer console for more information";

          if (!error.response) {
            title = "Unable to connect";
            text = "Did you start the backend server on the right port..?";
          }
          
          this.$swal({
            icon: "error",
            title,
            text,
            heightAuto: false,
          });
        });
    },
  },

  mounted() {
    window.EventBus.$on("url:set", this.startGame);
    window.EventBus.$on("url:clear", () => {
      this.id = null;
    });
  },
};
</script>

<style>
.board {
  text-align: center;
}

span {
  color: #6b4d39;
  font-weight: bold;
}
</style>
