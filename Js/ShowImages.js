
const IMAGES_OVEN_LENGTH = 25; 

var DivPrintImagesHTML = ""; 
for (var i = 2; i < IMAGES_OVEN_LENGTH; i += 2) 
    DivPrintImagesHTML += ` 
    <div> 
        <img data = "Files/Images/Image${i - 1}.jpg" alt = "Image" class = "Class_OurWorks_Main_DivPrintImages_Images" /> 
        <img data = "Files/Images/Image${i}.jpg" alt = "Image" class = "Class_OurWorks_Main_DivPrintImages_Images" /> 
    </div> `; 
ID_OurWorks_Main_DivPrintImages.innerHTML = DivPrintImagesHTML; 


const CONST_INTERSECTION_OBSERVER = new IntersectionObserver(function(ArrayObjects, Observer) 
{ 
    ArrayObjects.forEach(Object => 
        { 
            Object[`target`][`src`] = Object.intersectionRatio ? Object[`target`].getAttribute(`data`) : ``; 
        }); 
}, { root: null, rootMargin: `0px`, threshold: 0.1 }); 

const ARRAY_CLASS_OUR_WORKS_MAIN_DIV_PRINT_IMAGES = document.getElementsByClassName(`Class_OurWorks_Main_DivPrintImages_Images`); 

for (const CONST_IMAGE of ARRAY_CLASS_OUR_WORKS_MAIN_DIV_PRINT_IMAGES) 
    CONST_INTERSECTION_OBSERVER.observe(CONST_IMAGE); 

