/******************
 *  ТИПЫ ДЕЙСТВИЙ *
 ******************/

// Навигация по сайту
export const ACT_NAVIGATE = 'NAVIGATE'


/***************
 *  ГЕНЕРАТОРЫ *
 ***************/
export const navigate = (pageId = 0) => {
    return {
        type: ACT_NAVIGATE,
        id: pageId
    }
}