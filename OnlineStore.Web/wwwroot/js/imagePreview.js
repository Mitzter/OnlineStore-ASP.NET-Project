
const imageUrlInput = document.getElementById('imageUrlInput');
const imagePreview = document.getElementById('imagePreview');

imageUrlInput.addEventListener('input', function() {
    const imageUrl = this.value;


if (imageUrl) {
    imagePreview.src = imageUrl;
imagePreview.style.display = 'block';
    } else {

    imagePreview.src = '#';
imagePreview.style.display = 'none';
    }
});
