import api from './api'

async function startNewGame () {
  return api.getInstance()
    .post('/StartNewGame')
    .then(result => result.data)
}

async function quitGame (id) {
  return api.getInstance()
    .get('/QuitGame/' + id)
    .then(result => result.data)
}

async function getStatus (id) {
  return api.getInstance()
    .get('/Status/' + id)
    .then(result => result.data)
}

async function getAllPlayedRows (id) {
  return api.getInstance()
    .get('/AllPlayedRows/' + id)
    .then(result => (result.data || []).reverse())
}

async function doNextTry (id, values) {
  return api.getInstance()
    .post('/NextTry/' + id, values)
    .then(result => result.data)
}

export default {
  startNewGame,
  quitGame,
  getStatus,
  getAllPlayedRows,
  doNextTry
}
