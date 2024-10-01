var pins = [
  'black',
  'blue',
  'green',
  'red',
  'yellow',
  'white',
  'purple'
]

export function getPinColour (number) {
  if (pins.length > number) {
    return pins[number]
  }
  return null
}
