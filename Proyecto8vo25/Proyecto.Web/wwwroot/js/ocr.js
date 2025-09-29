window.recognizeTextFromImage = async function (fileInputId) {
    const { createWorker } = Tesseract;
    const input = document.getElementById(fileInputId);

    if (!input || !input.files || input.files.length === 0) {
        return "No se seleccionó ninguna imagen.";
    }

    const file = input.files[0];
    const imageURL = URL.createObjectURL(file);

    const worker = await createWorker('spa'); 
    const { data: { text } } = await worker.recognize(imageURL);
    await worker.terminate();

    return text;
};
