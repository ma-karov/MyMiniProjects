const ARRAY_CLASS_OUR_WORKS_MAIN_DIV_PRINT_IMAGES = document.getElementsByClassName(`Class_OurWorks_Main_DivPrintImages_Images`); 

window.addEventListener(`scroll`, function() 
{ 
    function GetOffsetForScrollObjectHTML(ObjectHTML) 
    { 
        var ObjectHTML_BoundingClientRect = ObjectHTML.getBoundingClientRect(), 
        ObjectHTML_BoundingClientRectScrolls = new Array( window[`pageXOffset`] || document[`documentElement`][`scrollLeft`], window[`pageYOffset`] || document[`documentElement`][`scrollTop`] ); 
        return new Array( ObjectHTML_BoundingClientRect[`left`] + ObjectHTML_BoundingClientRectScrolls[0], 
                            ObjectHTML_BoundingClientRect[`top`] + ObjectHTML_BoundingClientRectScrolls[1] ); 
    }

    for (const CONST_IMAGE of ARRAY_CLASS_OUR_WORKS_MAIN_DIV_PRINT_IMAGES) 
        if (!CONST_IMAGE[`src`])
        { 
            const CONST_IMAGE_HEIGHT = CONST_IMAGE[`offsetHeight`], CONST_IMAGE_HEIGHT_OFFSET = GetOffsetForScrollObjectHTML(CONST_IMAGE)[1]; 
            console.log(CONST_IMAGE_HEIGHT, CONST_IMAGE_HEIGHT_OFFSET); 

            const THRESHOLD = 0.01, WINDOW_INNER_HEIGHT = window[`innerHeight`], WINDOW_PAGE_Y_OFFSET = window[`pageYOffset`]; 
            var ConstImagePointVisible = WINDOW_INNER_HEIGHT - THRESHOLD*CONST_IMAGE_HEIGHT; 
            if (ConstImagePointVisible > WINDOW_INNER_HEIGHT) 
                ConstImagePointVisible = WINDOW_INNER_HEIGHT*(1 - THRESHOLD); 

            if (WINDOW_PAGE_Y_OFFSET > CONST_IMAGE_HEIGHT_OFFSET - ConstImagePointVisible && WINDOW_PAGE_Y_OFFSET < CONST_IMAGE_HEIGHT_OFFSET + ConstImagePointVisible)
                CONST_IMAGE[`src`] = CONST_IMAGE.getAttribute(`data`); 
        } 
    
})

