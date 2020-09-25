

//Index_Banner
$('.social').hide(function () {
    $(this).delay(12000).fadeIn(800);
});

$('.rw-sentence')
    .delay(10000)
    .fadeOut(400);

// End Index_Banner



//Header

// When the user scrolls the page, execute myFunction
window.onscroll = function () { myFunction() } ; 

// Get the header
var header = document.getElementById("myHeader");

// Get the offset position of the navbar
var sticky = header.offsetTop;

// Add the sticky class to the header when you reach its scroll position. Remove "sticky" when you leave the scroll position
function myFunction()  {
    if (window.pageYOffset > sticky) {
        header.classList.add("sticky");
    } else {
        header.classList.remove("sticky");
    }
}  

//End Header





