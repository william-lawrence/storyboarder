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

    // listen for a click on the get question button and gets the question.
    document.querySelector('button#start').addEventListener('click', (event) => {
        event.preventDefault();
        const newQuestion = getNewQuestion();
    });
});

let question; // The data pulled from the question API.
let score = 0; // this variable keeps track of the score as the number of the questions answered correctly.

/**
 * Gets a jeopardy question using the jservice API.
 */
function getNewQuestion() {
    const url = 'http://jservice.io/api/random'; // THANKS FOR THE APIs
    const settings = {
        method: 'GET'
    };

    fetch(url, settings)
        .then(response => response.json())
        .then(json => {
            console.log(json);
            question = json;
            addQuestionToPage(processQuestion(question));
            addEventHandlersForNewQuestion();
        });
}

/**
 * Removes leading <i> and trailing </i> from the answer if it exists.
 */
function processQuestion(question) {
    let processedAnswer = question[0].answer;
    if (processedAnswer.startsWith('<i>') && processedAnswer.endsWith('</i>')) processedAnswer = processedAnswer.substr(3, processedAnswer.length - 7);
    return question;
}

/**
 * Adds the question called from the API to the page.
 * @param {Object} question the question to be added to the page.
 */ 
function addQuestionToPage(question) {
    console.log('Adding question to page.');

    // Creates a copy of the question template.
    const questionTemplate = getElementFromTemplate('question-template');

    // Reveals the score.
    const p = document.querySelector('h2#score');
    p.classList.remove('hidden')

    // Hides the start button.
    document.querySelector('button#start').classList.add('hidden');

    // Reveals the reset button. 
    // This button is used to reset the score.
    document.querySelector('button#reset').classList.remove('hidden');

    // Sets the text of the question
    questionTemplate.querySelector('p.question-text').innerText = `${question[0].question}`;
    questionTemplate.querySelector('p.difficulty').innerText = `Difficulty: ${question[0].value}`;
    questionTemplate.querySelector('p.category').innerText = `Category: ${question[0].category.title}`;
    questionTemplate.querySelector('p.answer-text').innerText = `${question[0].answer}`; 

    document.querySelector('div#question').insertAdjacentElement('beforebegin', questionTemplate);
}

/**
 * Adds all the handlers to the buttons on the question template.   
 */
function addEventHandlersForNewQuestion() {
    document.querySelector('button#show-answer').addEventListener('click', (event) => {
        event.currentTarget.parentNode.classList.add('hidden');
        event.currentTarget.parentNode.nextElementSibling.classList.remove('hidden');
    });

    // Adds the event handlers to the 'correct' button.
    document.querySelector('button#correct').addEventListener('click', (event)=>{
        updateScoreForCorrectAnswer();
        removeQuestionFromPage();
        getNewQuestion();
    });

    // Adds the event handlers to the 'incorrect' button.
    document.querySelector('button#incorrect').addEventListener('click', (event)=>{
        removeQuestionFromPage();
        getNewQuestion();
    });

    // Adds the event handlers to the 'reset' button.
    document.querySelector('button#reset').addEventListener('click', (event) => {
        removeQuestionFromPage();
        resetScore();
        getNewQuestion();
    });
}

/**
 * updates the score when the user answer correctly.
 */
function updateScoreForCorrectAnswer() {
    score = score + question[0].value;
    document.querySelector('h2#score').innerText = score.toString();
}

/**
 * Resets the score of the game and updates it on the display.
 */
function resetScore() {
    score = 0; // Resets the score
    document.querySelector('h2#score').innerText = score.toString();
}

/**
 * Removes the current question and answer from the page. 
 */
function removeQuestionFromPage() {
    document.querySelector('div.question').remove();
    document.querySelector('div.answer').remove();
}
