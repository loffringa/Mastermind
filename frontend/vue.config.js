module.exports = {
  devServer: {
    host: 'localhost'
  },
  publicPath: process.env.NODE_ENV === 'production'
    ? '/ICT-VK-T-19-mastermind-frontend/'
    : '/'
}
