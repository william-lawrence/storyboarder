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

let boards;
let base = 'http://localhost:61815';


/**
 * Calls the API and Gets all the boards for the user.
 */
function getAllBoards() {
    const url = `${base}/api/boards`;
    const settings = {
        method: 'GET'
    };

    fetch(url, settings)
        .then(response => response.json())
        .then(json => {
            console.log(json);
            boards = json;
            addBoardsToPage(boards)
        });
}

/**
 * Adds all story cards to the page
 * @param {object} boards All the boards that were pulled from the API
 */
function addBoardsToPage(boards) {
    console.log('Adding Stories to page...');
    // Create a copy of the story template
    const storyTemplate = getElementFromTemplate('story-template');

    for (let i = 0; i < boards.length; i++) {
        let board = boards[i];
        storyTemplate.querySelector('h3.index-content-title').innerText = board.description;
        document.querySelector('div.index-content-wrapper').insertAdjacentElement('beforeend', storyTemplate);
    }
}