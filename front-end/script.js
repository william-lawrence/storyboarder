/**
 * Get a template DOM object from the DOM and return a usable DOM object
 * from the main node within it. Assumes that there is only one main parent
 * node in the template.
 * 
 * @param {string} id the id of the template element
 * @returns {Object} a deep clone of the templated element
 */
function getElementFromTemplate(id) {
    let domNode = document.importNode(document.getElementById(id).content, true).firstElementChild;

    return domNode;
}

// wait till the DOM is loaded to add JS content.
document.addEventListener('DOMContentLoaded', () => {
    getAllBoards();
});

let boards = [];
let base = 'http://localhost:61815';



function getAllBoards() {
    const url = `${base}/api/boards`;
    const settings = {
        method: 'GET'
    };

    fetch(url, settings)
        .then(response => response.json())
        .then(json => {
            console.log(json);
        });
}