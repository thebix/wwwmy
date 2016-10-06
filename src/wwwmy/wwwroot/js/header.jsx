//import React from 'react';

/* главный компонент шапки */
class Header extends React.Component {
    constructor(props){
        super(props);
    }
    render(){
        return(
            <HeaderTitle title={this.props.title} />
        );
    }
}
/* END главный компонент шапки END */

/* главный заголовк шапки */
class HeaderTitle extends React.Component {
    constructor(props){
        super(props);
    }
    render(){
        return (
            <h1 className="header-title">{this.props.title}</h1>
        );
    }
}



ReactDOM.render(
    <Header title="Заголовок Шапки" />,
        document.getElementById('header')
);  
/* END главный заголовк шапки END */