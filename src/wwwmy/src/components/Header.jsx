import React from 'react'

import Link from './Link'

const Header = ({children}) => {
    return (
        <div id="header">
            HEADER
            <Link isPseudo={true} pageId="0">
                Text link 0
            </Link>
            <Link isPseudo={false} pageId="1">
                Text link 1
            </Link>
            {children} 
        </div>
    )
}

export default Header