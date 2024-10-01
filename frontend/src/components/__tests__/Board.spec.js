
import Vue from 'vue';
import Board from '../Board.vue';
import { shallowMount } from "@vue/test-utils";

describe('Board.vue', () => {
    beforeAll(() => {
        window.EventBus = new Vue();
    })

    it('mounts', () => {
        shallowMount(Board);
    });

    it('starts a new game when restart is called', () => {
        const board = shallowMount(Board);

        let counter = 0;
        board.vm.startGame = () => {
            counter++;
        }
        board.vm.restart();

        expect(counter).toBe(1);
    })
})