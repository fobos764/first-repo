const square = index.getElementById('square');
let positionX = 0;

function animate() {
    positionX += 2; 
    if (positionX > window.innerWidth) {
        positionX = -50; 
    }

    square.style.left = positionX + 'px'; 
    requestAnimationFrame(animate); 
}

animate(); 