
const IMAGES_OVEN_LENGTH = 25; 

var DivPrintImagesHTML = ""; 
for (var i = 2; i < IMAGES_OVEN_LENGTH; i += 2) 
    DivPrintImagesHTML += ` 
    <div> 
        <img src = "Files/Images/Image${i - 1}.jpg" alt = "Image" class = "Class_OurWorks_Main_DivPrintImages_Images" /> 
        <img src = "Files/Images/Image${i}.jpg" alt = "Image" class = "Class_OurWorks_Main_DivPrintImages_Images" /> 
    </div> `; 

ID_OurWorks_Main_DivPrintImages.innerHTML = DivPrintImagesHTML; 






