/**
 * function that allows us to get a template by its ID
 * @param {any} id The id of the template to use.
 */
function getElementFromTemplate(id) {
    let domNode = document.importNode(document.getElementById(id).content, true).firstElementChild;

    return domNode;
}

// The boards that are received from the API and added to the page
let boards;
//base variable ensures that we are properly access the url of the current development environment.
let base = window.location.protocol + "//" + window.location.host;


// Ensures that the page is fully loaded before scripts run.
document.addEventListener('DOMContentLoaded', () => {
    console.log('DOM Loaded');

    // Once the DOM is fully loaded, get all the boards for the user and add them to the page.
    getBoardsForUser();
    
});

function getBoardsForUser() {
    const url = `${base}/board/getboardsforuser`;
    const settings = {
        method: 'GET',
        credentials: 'include'
    };

    fetch(url, settings)
        .then(response => response.json())
        .then(json => {
            console.log(json);
            boards = json;
            addBoardsToPage(boards);
        });
}

function addBoardsToPage(boards) {
    for (let i = 0; i < boards.length; i++) {

        const newBoard = getElementFromTemplate('new-board');

        newBoard.querySelector('h2.board-content-title').innerText = boards[i].title;
        newBoard.querySelector('p.board-content-description').innerText = boards[i].description;
        newBoard.querySelector('button.view-scenes')

        // This is the snippet that we need to add the function to the button.
        // newLocationDiv.querySelector('a').setAttribute("href", `location/detail/${locationArray[i].id}?distanceFromUser=${locationArray[i].distanceFromUser}`);

        document.querySelector('div.user-boards').insertAdjacentElement('afterbegin', newBoard);
    }
}