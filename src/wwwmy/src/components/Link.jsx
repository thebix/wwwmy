import React from 'react'

const Link = ({isPseudo, pageId, children}) => {
    if(isPseudo) {
        return (<span className='dynamic' data-id={pageId}>{children}</span>)
    } else {
        return (<a href={pageId}>{children}</a>)
    }
}

export default Link