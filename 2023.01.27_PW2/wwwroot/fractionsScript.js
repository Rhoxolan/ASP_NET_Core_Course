document.getElementById('addFromFileButton').addEventListener("click", e => {
    e.preventDefault();
    const fileInput = document.createElement('input');
    fileInput.type = 'file';
    fileInput.accept = ".json";
    fileInput.addEventListener('change', () => {
        const reader = new FileReader();
        reader.addEventListener('load', () => {
            const fractions = JSON.parse(reader.result);
            document.getElementById("leftTopFractionInput").value = fractions.leftTopFraction;
            document.getElementById("leftBottomFractionInput").value = fractions.leftBottomFraction;
            document.getElementById("rightTopFractionInput").value = fractions.rightTopFraction;
            document.getElementById("rightBottomFractionInput").value = fractions.rightBottomFraction;
        });
        reader.readAsText(fileInput.files[0]);
    });
    fileInput.click();
});