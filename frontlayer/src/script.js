// импортируем функцию
import { getMap } from './map.js'

document.getElementById('my_position').onclick = () => {
    console.log('click');
  navigator.geolocation.getCurrentPosition(success, error, {
    enableHighAccuracy: true
  })
}

function success({ coords }) {
  const { latitude, longitude } = coords
  const currentPosition = [latitude, longitude]
  getMap(currentPosition, 'You are here')
}

function error({ message }) {
  console.log(message)
}