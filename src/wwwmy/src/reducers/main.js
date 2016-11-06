import {
    ACT_NAVIGATE, 
    navigate
} from '../actions/main'

const initState = {
    currentPageId: 0
}

const currentPageId = (state = 0, action) => {
    switch (action.type) {
        case ACT_NAVIGATE:
            return action.id;
        default:
            return state
    };
}

const appReducer = (state = {}, action) => {
    return {
        currentPageId: currentPageId(state.currentPageId, action)
    }
}

export default appReducer
