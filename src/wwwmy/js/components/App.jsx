import React from 'react'
import ReactDOM from 'react-dom'

const App = () => {
    return (
        <div id="wrapper">
            <div id="header">
                HEADER
            </div>
            <div id="body">
                BODY
            </div>
            <div id="footer">
                FOOTER
            </div>
        </div>
    )
}

ReactDOM.render(
    <App />, document.getElementById("root")
)