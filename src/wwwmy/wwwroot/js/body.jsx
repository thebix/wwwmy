//import React from 'react';

/* главный компонент тела */
class Body extends React.Component {
    constructor(props){
        super(props);
    }
    render(){
        return(
            <BodyTitle title={this.props.title} />
        );
    }
}
/* END главный компонент тела END */

/* главный заголовк тела */
class BodyTitle extends React.Component {
    constructor(props){
        super(props);
    }
    render(){
        return (
            <h1 className="body-title">{this.props.title}</h1>
        );
    }
}

ReactDOM.render(
            <Body title="Заголовок Тела" />,
                document.getElementById('body')
        );  
/* END главный заголовк тела END */