//http://stackoverflow.com/questions/38002666/dev-server-not-hot-reloading-failing-to-build

// Dev server / HMR
const webpack = require('webpack');
const WebpackDevServer = require('webpack-dev-server');
const config = require('./webpack.config.js');
const compiler = webpack(config);

new WebpackDevServer(compiler, {
  port: 3001,
  publicPath: '/js/',
  contentBase: 'js/',
  historyApiFallback: true,
  inline: true,
  hot: false, //TODO: не работает
  quiet: false,
  stats: { colors: true },
  proxy: {
    '*': 'http://localhost:3000'
  }
}).listen(3001, 'localhost', (err, result) => {
  if (err){
    console.log(err);
  }
  console.log('WebpackDevServer[localhost::3001]');
});


/* **************************** 
 * Еще один вариант           *
 * ****************************/

// var webpack = require('webpack');  
// var WebpackDevServer = require('webpack-dev-server');  
// var config = require('./webpack.config');

// new WebpackDevServer(webpack(config), {  
//     publicPath: config.output.publicPath,
//     hot: true,
//     historyApiFallback: true,
//     headers: { 'Access-Control-Allow-Origin': '*' }
// }).listen(3000, 'localhost', function (err, result) {
//     if (err) {
//         console.log(err);
//     }

//     console.log('Listening at localhost:3000');
// });


/* **************************** 
 * Еще один вариант           *
 * ****************************/

// console.log("===========================NODE SERVER===========================");

// var path = require('path');
// var webpack = require('webpack');
// var express = require('express');
// var config = require('./webpack.config');

// var app = express();
// var compiler = webpack(config);
// console.log("========config.output.publicPath =" + config.output.publicPath);
// app.use(require('webpack-dev-middleware')(compiler, {
//   publicPath: config.output.publicPath
// }));

// app.use(require('webpack-hot-middleware')(compiler));

// console.log("============__dirname = " + __dirname);
// app.get('*', function(req, res) {
//   res.sendFile(path.join(__dirname, 'index.html'));
// });

// app.listen(3000, function(err) {
//   if (err) {
//     return console.error(err);
//   }

//   console.log('Listening at http://localhost:3000/');
// })