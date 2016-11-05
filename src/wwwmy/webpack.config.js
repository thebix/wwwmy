var path = require('path');
var webpack = require('webpack');

// module.exports = {
//   entry: './wwwroot/js/startUp.js',
//   //output: { path: __dirname, filename: 'bundle.js' },
//       output: {
//         path: './wwwroot/js2',
//         filename: 'app.bundle.js'
//     },
//   module: {
//     loaders: [
//       {
//         test: /.jsx?$/,
//         loader: 'babel-loader',
//         exclude: /node_modules/,
//         query: {
//           presets: ['es2015', 'react']
//         }
//       }
//     ]
//   },
// };


module.exports = [
  {
    entry: {
      jquery: './node_modules/jquery/dist/jquery.js',
      //react: './node_modules/react/dist/react.js'
    },
    output: {
      filename: './wwwroot/js/[name].min.js'
    },
    target: 'web',
    node: {
      fs: "empty"
    }
  },
  {
    entry: {
      app: './js/startUp.js'
    },
    output: {
      filename: './wwwroot/js/bundle.js'
    },
    devtool: 'source-map',
    // resolve: {
    //   extensions: ['', '.webpack.js', '.web.js', '.ts', '.js']
    // },
    module: {
      loaders: [
        {
          test: /.jsx?$/,
          loader: 'babel-loader',
          exclude: /node_modules/,
          query: {
            presets: ['es2015', 'react']
          }
        }
      ]
    }
  }];

// module.exports = {
//     entry: [
//         './wwwroot/js/app.js',
//         "./wwwroot/js/components/app.jsx"
//         //'./wwwroot/js/startUp.js',
//         //'./wwwroot/js/body.jsx'
//     ],
//     output: {
//         path: './wwwroot/js2',
//         filename: 'app.bundle.js'
//     },
//     module: {
//         loaders: [{
//             test: /\.jsx?$/,
//             exclude: /node_modules/,
//             loader: 'babel-loader'
//         }]
//     },
//     plugins: [
//     new webpack.optimize.UglifyJsPlugin({
//         compress: {
//             warnings: false,
//         },
//         output: {
//             comments: false,
//         },
//     }),
// ]
     
//  };