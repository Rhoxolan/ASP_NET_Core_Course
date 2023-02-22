document.getElementById('addFromFileButton').addEventListener("click", onAddFromFileButtonClick);

function onAddFromFileButtonClick(e) {
    e.preventDefault();
    const fileInput = document.createElement('input');
    fileInput.type = 'file';
    fileInput.accept = ".json";
    fileInput.addEventListener('change', () => onInputChange(fileInput));
    fileInput.click();
}

function onInputChange(fileInput) {
    const reader = new FileReader();
    reader.addEventListener('load', () => onFileReaderLoad(reader));
    reader.readAsText(fileInput.files[0]);
}

function onFileReaderLoad(reader) {
    const fractions = JSON.parse(reader.result);
    document.getElementById("leftTopFractionInput").value = fractions.leftTopFraction;
    document.getElementById("leftBottomFractionInput").value = fractions.leftBottomFraction;
    document.getElementById("rightTopFractionInput").value = fractions.rightTopFraction;
    document.getElementById("rightBottomFractionInput").value = fractions.rightBottomFraction;
}