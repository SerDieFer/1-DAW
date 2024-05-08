
// VARIABLES WHICH ASIGN THEM THE SELECTED BUTTONS ID
let btnTable = document.getElementById("btnTable")
let btnEmptyCell = document.getElementById("btnEmptyCell")
let btnDeleteCell = document.getElementById("btnDeleteCell")
let btnTextCell = document.getElementById("btnTextCell")
let btnEmptyRow = document.getElementById("btnEmptyRow")
let btnDeleteRow = document.getElementById("btnDeleteRow")
let btnTextRow = document.getElementById("btnTextRow")
let btnEmptyColumn = document.getElementById("btnEmptyColumn")
let btnDeleteColumn = document.getElementById("btnDeleteColumn")
let btnTextColumn = document.getElementById("btnTextColumn")

var textToChange // VARIABLE THAT STORES A SELECTED TEXT

// FUNCTION WHICH CREATES TABLE WITH A SELECTED SIZE BY USER (ROWS x COLUMNS)
function createTable(rowsNum, columnsNum) 
{
    let table = document.getElementById("table") // SELECTS TABLE ELEMENT

    for (let y = 1; y <= rowsNum; y++) // ITERATES BETWEEN FIRST ELEMENT UNTIL THE SELECTED ROW LENGTH
    {
        let row = document.createElement("tr") // CREATES A TR ("ROW")

        for (let x = 1; x <= columnsNum; x++) // ITERATES BETWEEN FIRST ELEMENT UNTIL THE SELECTED COLUMN LENGTH
        {
            let cell = document.createElement("th"); // CREATES A CELL IN THE COLUMN POSITION (X)
            cell.innerHTML = "Cell Nº" + x // ADDS A TEXT TO THE CELL
            row.appendChild(cell) // ADDS THE CELL IN X POSITION TO THE ROW IN POSITION Y
        }
        table.appendChild(row) // ADDS THE FULLY ROW WITH THE RESPECTIVE CELLS(COLUMNS) TO THE TABLE
    }
    appliesTableStyle() // APPLIES SOME CSS TO THE TABLE
}

// FUNCTION WHICH APPLIES CSS STYLES TO CERTAIN ELEMENTS IN THE TABLE
function appliesTableStyle() {
    let table = document.getElementById("table") // SELECTS TABLE ELEMENT
    let trElements = document.getElementsByTagName("tr") // SELECTS ALL TR(ROW) ELEMENTS
    let thElements = document.getElementsByTagName("th") // SELECTS ALL TH/*TD(COLUMN/*CELL) ELEMENTS

    table.style.border = "1px solid black" // STYLE FOR THE BORDER OF THE TABLE

    for (let i = 0; i < thElements.length; i++) // ITERATES BETWEEN FIRST UNTIL LAST TH ELEMENT IN THE TABLE
    {
        thElements[i].style.border = "1px solid black" // STYLE FOR THE TH ELEMENT Nºi OF THE TABLE
    }
    for (let i = 0; i < trElements.length; i++) // ITERATES BETWEEN FIRST UNTIL LAST TR ELEMENT IN THE TABLE
    {
        trElements[i].style.border = "1px solid black" // STYLE FOR THE TR ELEMENT Nºi OF THE TABLE
    }
}

// FUNCTION WHICH RETURNS THE POSITION OF A CELL INSIDE THE FULL TABLE (ROW x COLUMN)
function selectCell(rowsNum, columnsNum) 
{
    let allRows = document.getElementsByTagName("tr") // SELECTS ALL TR(ROW) ELEMENTS

    if (rowsNum <= allRows.length)  // IF THE ROW EXIST
    {
        let allCellsInRow = allRows[rowsNum - 1].children // SELECTS ALL THE CHILDREN OF THIS ROW
        
        if (columnsNum <= allCellsInRow.length)  // SELECTS ALL TH(COLUMN/*CELL) ELEMENTS
        {
            let cellSelected = allCellsInRow[columnsNum - 1]  // SELECTS THE CELL IN A CERTAIN COLUMN FROM THIS ROW
            return cellSelected // RETURNS BACK THE SELECTED CELL
        }
    }
    return false // THE CELL DOESNT EXIST
}

// FUNCTION WHICH RETURNS THE POSITION OF A SELECTED ROW AND ITS ELEMENTS
function selectRow(rowsNum) 
{
    let allRows = document.getElementsByTagName("tr") // SELECTS ALL TR(ROW) ELEMENTS

    if (rowsNum > 0 && rowsNum <= allRows.length) // IF THE ROW EXIST
    {
        let selectedRow = allRows[rowsNum - 1] // SELECTS THE ROW POSITION
        return selectedRow // RETURNS BACK THE SELECTED ROW
    }

    return false // THE ROW DOESNT EXIST
}

// FUNCTION WHICH RETURNS THE POSITION OF A SELECTED COLUMN AND ITS ELEMENTS
function selectColumn(columnsNum) 
{
    let allRows = document.getElementsByTagName("tr") // SELECTS ALL TR(ROW) ELEMENTS
    let selectedColumn = [] // CREATES AN ARRAY TO STORE COLUMN ELEMENTS (CELLS FROM ANOTHER ROW BUT SAME COLUMM)

    for (let i = 0; i < allRows.length; i++) // ITERATES BETWEEN FIRST ROW POSITION UNTIL LAST ONE
    {
        let cellsInRow = allRows[i].children // SELECTS ALL THE CHILDREN FROM ROW IN POSITION Nºi

        if (columnsNum <= cellsInRow.length)  // IF THE COLUMN/CELL EXIST IN THE ROW
        {
            selectedColumn.push(cellsInRow[columnsNum - 1]) // ADDS THE CELLS INTO THE SELECTED COLUMN FROM ALL ROWS

            // selectedColumn[i] = cellsInRow[columnsNum - 1] WAS THE ONE I TRIED
            // USING PUSH ENSURES THAT EACH CELL IS ADDED TO THE ARRAY WITHOUT RELYING ON A SPECIFIC INDEX (i)
            // THIS APPROACH IS BETTER IN HANDLING TABLES WITH VARIABLE COLUMN LENGTHS. I HAD TO SEATCH THIS

        }
    }
    return selectedColumn // RETURNS BACK THE COLUMN POSITION
}

//FUNCTION WHICH ASK THE USER TO IMPUT A NUMBER OF ROWS
function rowsNum() 
{
    let rNum = prompt("Row Selection: ")

    if(rNum === null || rNum.trim() === "" || rNum <= 0)
    {
        alert("You can't select NULL or negative rows")
    }
    else
    {
        return rNum
    }
}

//FUNCTION WHICH ASK THE USER TO IMPUT A NUMBER OF COLUMNS
function columnsNum() 
{
    let cNum = prompt("Column Selection: ")

    if(cNum === null || cNum.trim() === "" || cNum <= 0)
    {
        alert("You can't select NULL or negative columns")
    }
    else
    {
        return cNum
    }
}

// EVENT THAT ACTIVATES THE CREATION OF THE TABLE
btnTable.addEventListener("click", function() 
{
    let rows = rowsNum()
    let columns = columnsNum()
    createTable(rows,columns)
})

// EVENT THAT EMPTIES THE TEXT INSIDE A SELECTED CELL
btnEmptyCell.addEventListener("click", function() 
{
    let rows = rowsNum()
    let columns = columnsNum()
    let cellToDelete = selectCell(rows, columns)

    if (cellToDelete) 
    {
        cellToDelete.innerHTML = " " // CHANGES TEXT TO AN INVISIBLE CHARACTER ONE
        alert("Cell emptied successfully")
    } 
    else 
    {
        alert("Cell not found")
    }
})

// EVENT THAT DELETES FROM THE TABLE A SELECTED CELL
btnDeleteCell.addEventListener("click", function() 
{
    let rows = rowsNum()
    let columns = columnsNum()
    let cellToDelete = selectCell(rows, columns)

    if (cellToDelete) 
    {
        cellToDelete.remove() // REMOVES THE CELL
        alert("Cell deleted successfully")
    } 
    else 
    {
        alert("Cell not found")
    }
})

// EVENT THAT EMPTIES THE TEXT INSIDE ALL THE CELLS FROM A SELECTED ROW
btnEmptyRow.addEventListener("click", function() 
{
    let rows = rowsNum()
    let rowToEmpty = selectRow(rows)

    if (rowToEmpty) 
    {
        let rowCells = rowToEmpty.children; // ALL CHILDREN OF THAT ROW ELEMENT

        for (let i = 0; i < rowCells.length; i++) 
        {
            rowCells[i].innerHTML = " " // CHANGES TEXT TO AN INVISIBLE CHARACTER ONE FROM A CELL IN POSITION Nºi IN THE SELECTED ROW
        }
        alert("Row emptied successfully")
    }
    else 
    {
        alert("Row not found")
    }
})

// EVENT THAT REMOVES A SELECTED ROW
btnDeleteRow.addEventListener("click", function() 
{
    let rows = rowsNum()
    let rowToDelete = selectRow(rows) 

    if (rowToDelete) 
    {
        rowToDelete.remove(); // REMOVES THE ROW
        alert("Row deleted successfully")
    }
    else 
    {
        alert("Row not found")
    }
})

// EVENT THAT EMPTIES THE TEXT INSIDE ALL THE CELLS WHICH COMES FROM DIFFERENT ROWS AND THEY HAVE THE SAME SELECTED COLUMN 
btnEmptyColumn.addEventListener("click", function() 
{
    let columns = columnsNum()
    let columnToEmpty = selectColumn(columns)

    if (columnToEmpty) 
    {
        let columnCells = columnToEmpty.children; // SELECTS ALL THE CHILDREN THAT MATCH THAT COLUMN

        for (let i = 0; i < columnToEmpty.length; i++) 
        {
            columnToEmpty[i].innerHTML = " " // CHANGES TEXT TO AN INVISIBLE CHARACTER ONE FROM A DIFFERENT ROW AND CELL IN POSITION Nºi IN THE SELECTED COLUMN
        }
        alert("Column emptied successfully")
    }
    else 
    {
        alert("Column not found")
    }
})

// EVENT THAT REMOVES A SELECTED COLUMN
btnDeleteColumn.addEventListener("click", function() 
{
    let columns = columnsNum()
    let columnToDelete = selectColumn(columns)

    if (columnToDelete.length > 0) 
    {
        for (let i = 0; i < columnToDelete.length; i++) 
        {
            columnToDelete[i].remove() // REMOVES THE COLUMN AND ALL THE ELEMENTS FROM DIFFERENT ROWS WHICH MATCH THAT COLUMN POSITION
        }
        alert("Column deleted successfully")
    }
    else 
    {
        alert("Column not found")
    }
})

// EVENT THAT SELECTS THE TEXT IN THE TEXT AREA AND ASIGNS IT TO A VARIABLE
btnTextChanger.addEventListener("click", function() 
{
    let text = document.getElementById("textChanger").value // GET THE VALUE FROM THE TEXT AREA
    if (text !== "" || text !== NULL) 
    {
        textToChange = text
        alert("Text set successfully")
    } 
})

// EVENT THAT CHANGES THE TEXT INSIDE A SELECTED CELL
btnTextCell.addEventListener("click", function() 
{
    let rows = rowsNum()
    let columns = columnsNum()
    let cellToChange = selectCell(rows, columns)

    if (cellToChange) 
    {
        cellToChange.innerHTML = textToChange // CHANGES TEXT TO A SELECTED ONE
        alert("Cell text changed successfully")
    } 
    else 
    {
        alert("Cell not found")
    }
})

// EVENT THAT CHANGES THE TEXT INSIDE ALL THE CELLS FROM A SELECTED ROW
btnTextRow.addEventListener("click", function() 
{
    let rows = rowsNum()
    let rowToChange = selectRow(rows)

    if (rowToChange) 
    {
        let rowCells = rowToChange.children; // ALL CHILDREN OF THAT ROW ELEMENT

        for (let i = 0; i < rowCells.length; i++) 
        {
            rowCells[i].innerHTML = textToChange// CHANGES TEXT TO A SELECTED ONE FROM A CELL IN POSITION Nºi IN THE SELECTED ROW
        }
        alert("Row changed successfully")
    }
    else 
    {
        alert("Row not found")
    }
})

// EVENT THAT CHANGES THE TEXT INSIDE ALL THE CELLS WHICH COMES FROM DIFFERENT ROWS AND THEY HAVE THE SAME SELECTED COLUMN 
btnTextColumn.addEventListener("click", function() 
{
    let columns = columnsNum()
    let columnToChange = selectColumn(columns)

    if (columnToChange.length > 0) 
    {
        for (let i = 0; i < columnToChange.length; i++) 
        {
            columnToChange[i].innerHTML = textToChange // CHANGES ALL THE COLUMN ELEMENTSFROM DIFFERENT ROWS WHICH MATCH THAT COLUMN POSITION
        }
        alert("Column changed successfully")
    }
    else 
    {
        alert("Column not found")
    }
})
