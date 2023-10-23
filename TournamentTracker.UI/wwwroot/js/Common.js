function ShowModal(ModalId) {

    let myModal = GetModal(ModalId);
    myModal.show();
}

function CloseModal(ModalId) {

    try {
        let myModal = GetModal(ModalId);
        myModal.hide();
    } catch (error) {
        alert(error);
    }

}

function GetModal(ModalId) {

    let myModal = document.getElementById(ModalId);

    if (myModal === null) {
        alert("Modal not found!");
    } else {
        return bootstrap.Modal.getOrCreateInstance(myModal);
    }

}