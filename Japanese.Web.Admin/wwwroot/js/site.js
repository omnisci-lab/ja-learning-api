// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function addSubFormFieldElement(formFieldName, index) {
    let newDivElement = document.createElement('div');
    newDivElement.classList = 'row';
    newDivElement.id = `formSubGroup_${formFieldName}_${index}_`;
    newDivElement.setAttribute('idx', index);

    let newSubDivElement1 = document.createElement('div');
    newSubDivElement1.classList = 'col-11';

    let newSubDivElement2 = document.createElement('div');
    newSubDivElement2.classList = 'col-1';

    let newInputElement = document.createElement('input');
    newInputElement.classList = 'form-control my-2';
    newInputElement.id = `${formFieldName}_${index}_`;
    newInputElement.setAttribute("idx", index);
    newInputElement.type = 'text';
    newInputElement.name = `${formFieldName}[${index}]`;
    newInputElement.value = '';

    let newButtonElement = document.createElement('button');
    newButtonElement.classList = 'btn btn-sm btn-danger my-2';
    newButtonElement.type = 'button';
    newButtonElement.style.padding = '7px';
    newButtonElement.setAttribute('onclick', `deleteSubFormField('${formFieldName}', ${index})`);
    newButtonElement.innerText = "Delete";

    newSubDivElement1.appendChild(newInputElement);
    newSubDivElement2.appendChild(newButtonElement);

    newDivElement.appendChild(newSubDivElement1);
    newDivElement.appendChild(newSubDivElement2);

    return newDivElement;
}

function addSubFormField(formFieldName) {
    let formSubGroupElement = document.getElementById(`formSubGroup_${formFieldName}`);

    let divElements = formSubGroupElement.getElementsByClassName('row');

    if (divElements.length == 0) {
        formSubGroupElement.appendChild(addSubFormFieldElement(formFieldName, 0));
    } else {
        let lastDivElement = divElements[divElements.length - 1];
        let lastIndex = lastDivElement.getAttribute('idx');

        formSubGroupElement.appendChild(addSubFormFieldElement(formFieldName, parseInt(lastIndex) + 1));
    }
}

function deleteSubFormField(formFieldName, index) {
    const element = document.getElementById(`formSubGroup_${formFieldName}_${index}_`);
    element.remove();

    let formSubGroupElement = document.getElementById(`formSubGroup_${formFieldName}`);

    let divElements = formSubGroupElement.getElementsByClassName("row");
    for (let i = 0; i < divElements.length; i++) {
        divElements[i].id = `formSubGroup_${formFieldName}_${i}_`;
        divElements[i].setAttribute("idx", i);

        let inputElements = divElements[i].getElementsByTagName('input');
        inputElements[0].id = `${formFieldName}_${i}_`;
        inputElements[0].name = `${formFieldName}[${i}]`;

        let buttonElements = divElements[i].getElementsByTagName('button');
        buttonElements[0].setAttribute('onclick', `deleteSubFormField('${formFieldName}', ${i})`);
    }
}