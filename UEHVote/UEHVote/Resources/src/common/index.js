export const hookFileUploadEvent = async (previewImg, fileUploadRefId, discardBtn, imgContainerId, originalSrc) => {
    const discardContainer = document.getElementById(imgContainerId);
    if (discardContainer && discardBtn && previewImg) {
        discardBtn.removeEventListener("click", onDiscardBtnClicked(previewImg, originalSrc));
        discardBtn.addEventListener("click", onDiscardBtnClicked(previewImg, originalSrc));
    }

    const fileUpload = document.getElementById(fileUploadRefId);
    if (fileUpload && previewImg) {
        fileUpload.removeEventListener('change', onImageChanged(previewImg));
        fileUpload.addEventListener('change', onImageChanged(previewImg));
    }

    const bsCustomFileInput = await import('bs-custom-file-input');
    bsCustomFileInput.init();
}

const onImageChanged = (previewImg) => (event) => {
    previewImg.src = URL.createObjectURL(event.target.files[0]);
    previewImg.onload = () => {
        URL.revokeObjectURL(previewImg.src);
    };
};

const onDiscardBtnClicked = (previewImg, originalSrc) => () => {
    previewImg.src = originalSrc;
};