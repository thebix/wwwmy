//http://stackoverflow.com/questions/38002666/dev-server-not-hot-reloading-failing-to-build

const webpack = require('webpack');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const validate = require('webpack-validator');
const path = require('path');

const rootPath = path.resolve(__dirname, 'src');

var isProduction = process.env.NODE_ENV === 'production'; //TODO: не работает

console.log("\n****************************************")
console.log("* Webpack render. IsProduction = " + isProduction.toString().toUpperCase() + " *")
console.log("****************************************")

var entryPoint = path.resolve(rootPath, 'startUp.js')
var app = isProduction ? [entryPoint] : [
    'webpack-dev-server/client?http://localhost:3001',
    'webpack/hot/only-dev-server', // "only" prevents reload on syntax errors
    entryPoint
];

const config = {
  entry: {
    app: app,
    jquery: './node_modules/jquery/dist/jquery.js'
  },
  resolve: {
    extensions: ["", ".webpack.js", ".web.js", ".js", ".jsx"],
    root: rootPath
  },
  output: {
    path: path.resolve(__dirname, 'wwwroot', 'js'),
    publicPath: '/js/',
    filename: '[name].min.js',
    sourceMapFilename: '[name].min.map'
  },
  module: {
    loaders: [
      {
        test: /\.jsx?$/,
        exclude: [path.resolve(__dirname, 'node_modules')],
        loader: 'babel-loader',
        include: rootPath
      }, 
      // {
      //   test: /\.scss$/,
      //   loader: ExtractTextPlugin.extract('css?modules&importLoaders=1&localIdentName=[name]__[local]___[hash:base64:5]!sass'),
      //   include: rootPath
      // }, {
      //   test: /\.(png|jpg|gif)$/,
      //   loader: 'file?name=/images/[name].[ext]',
      //   include: rootPath
      // }
    ]
  },
  devtool: '#source-map',
  plugins: [
    new webpack.HotModuleReplacementPlugin(),
    //new webpack.NoErrorsPlugin(),
    //new ExtractTextPlugin('styles.css')
  ],
  devServer: {
      headers: { "Access-Control-Allow-Origin": "*" }
  }
};

module.exports = validate(config);





/* **************************** 
 * Еще один вариант           *
 * ****************************/
 
// var path = require('path');
// var webpack = require('webpack');
// var webpack = require('webpack');
// var path = require('path');
// var outFolder = path.resolve(__dirname, "./src");
// var isProduction = process.env.NODE_ENV === 'production ';

// var entryPoint = "./src/startUp.js"

// var app = ['webpack/hot/dev-server',
//     'webpack-hot-middleware/client?path=//localhost:3000/__webpack_hmr', 
//     entryPoint
// ];

// console.log("isProduction = " + isProduction);

// module.exports = {
//     entry: {
//         app: app,
//         jquery: './node_modules/jquery/dist/jquery.js'
//     },
//     output: {
//         path: outFolder,
//         filename: "[name].min.js",
//         publicPath: '/'
//     },
//     devtool: "source-map",
//     minimize: false,
//     module: {
//         loaders: [{
//             test: /\.(js|jsx)$/,
//             loader: 'babel-loader',
//             exclude: /node_modules/,
//             query: {
//               presets: ['es2015', 'react','react-hmre'],
//               plugins: ['react-hot-loader/babel']
//             }
//         },
//         {
//             test: /\.(css|less)$/,
//             loaders: ['style','css','less']
//         }]
//     },
//     plugins: [
//       new webpack.HotModuleReplacementPlugin()
//     ],
//     resolve: {
//         extensions: ["", ".webpack.js", ".web.js", ".js", ".jsx"]
//     },
//     devServer: {
//         headers: { "Access-Control-Allow-Origin": "*" }
//     }
// };



/* **************************** 
 * Еще один вариант           *
 * ****************************/

// var path = require('path')
// var webpack = require('webpack')

// module.exports = {
//   devtool: '#cheap-module-eval-source-map', // http://webpack.github.io/docs/configuration.html#devtool
//   entry: {
//         app: ['webpack-hot-middleware/client?path=http://localhost:3000/__webpack_hmr',
//           "./src/startUp.js"],
//         jquery: './node_modules/jquery/dist/jquery.js'
//     },
//   output: {
//     path: path.join(__dirname, 'src'),
//     filename: '[name].min.js',
//     publicPath: 'http://localhost:3000/static/'
//   },
//   plugins: [
//     new webpack.HotModuleReplacementPlugin(),
//     new webpack.NoErrorsPlugin()
//   ],
//   module: {
//     loaders: [{
//       test: /\.jsx?$/,
//       loader: 'babel-loader',
//       include: path.join(__dirname, 'src'),
//       query: {
//               presets: ['es2015', 'react','react-hmre'],
//               plugins: ['react-hot-loader/babel']
//             }
//     }]
//   }
// }