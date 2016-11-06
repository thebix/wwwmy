import React from 'react'
import ReactDOM from 'react-dom'
import {createStore} from 'redux'
import {Provider} from 'react-redux'

import Header from './Header'
import Footer from './Footer'
import Body from './Body'

import appReducer from '../reducers/main'

//redux store
let store = createStore(appReducer)

const App = () => {
    return (
        <div id="root">
            <Header />
            <Body />
            <Footer />
        </div>
    )
}

ReactDOM.render(
    <Provider store={store}>
        <App />
    </Provider>, document.getElementById("wrapper")
)