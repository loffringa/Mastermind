import axios from 'axios'

function getApiUrl () {
  return window.localStorage.getItem('apiurl')
}

function setApiUrl (url) {
  window.localStorage.setItem('apiurl', url)
}

function getInstance () {
  return axios.create({
    baseURL: getApiUrl(),
    timeout: 1000,
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    }
  })
}

export default {
  getApiUrl,
  setApiUrl,
  getInstance
}
