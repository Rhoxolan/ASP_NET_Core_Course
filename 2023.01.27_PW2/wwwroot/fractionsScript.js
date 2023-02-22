document.getElementById('addFromFileButton').addEventListener("click", e => {
    e.preventDefault();
    const fileInput = document.createElement('input');
    fileInput.type = 'file';
    fileInput.click();
    fileInput.addEventListener('change', () => {
        let fractions = JSON.parse(fileInput.files[0]);
        document.getElementById("leftTopFractionInput").innerText = fractions.leftTopFraction;
        document.getElementById("leftBottomFractionInput").innerText = fractions.leftBottomFraction;
        document.getElementById("rightTopFractionInput").innerText = fractions.rightTopFraction;
        document.getElementById("rightBottomFractionInput").innerText = fractions.rightBottomFraction;
    })
});