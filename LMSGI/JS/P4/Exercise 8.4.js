let btnTable = document.getElementById("btnTable")
let btnEmptyCell = document.getElementById("btnEmptyCell")
let btnDeleteCell = document.getElementById("btnDeleteCell")
let btnEmptyRow = document.getElementById("btnEmptyRow")
let btnDeleteRow = document.getElementById("btnDeleteRow")
let btnDeleteColumn = document.getElementById("btnDeleteColumn")

function createTable(rowsNum, columnsNum) 
{
    let table = document.getElementById("table")
    for (let y = 1; y <= rowsNum; y++) 
    {
        let row = document.createElement("tr")
        for (let x = 1; x <= columnsNum; x++) 
        {
            let cell = document.createElement("td");
            cell.innerHTML = "Cell Nº" + x
            row.appendChild(cell)
        }
        table.appendChild(row);
    }
}

function selectCell(rowsNum, columnsNum) 
{
    let allRows = document.getElementsByTagName("tr");

    if (rowsNum <= allRows.length) 
    {
        let allCellsInRow = allRows[rowsNum - 1].children;
        
        if (columnsNum <= allCellsInRow.length) 
        {
            let cellSelected = allCellsInRow[columnsNum - 1];
            return cellSelected;
        }
    }
    return false; 
}

function selectRow(rowsNum) 
{
    let allRows = document.getElementsByTagName("tr");

    if (rowsNum > 0 && rowsNum <= allRows.length) 
    {
        let selectedRow = allRows[rowsNum - 1];
        return selectedRow
    }

    return false;
}

//TODO
function selectColumn(columnsNum) 
{
    let allRows = document.getElementsByTagName("tr");

    if (rowsNum > 0 && rowsNum <= allRows.length) 
    {
        let selectedRow = allRows[rowsNum - 1];
        return selectedRow
    }

    return false;
}
//

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

btnTable.addEventListener("click", function() 
{
    let rows = rowsNum()
    let columns = columnsNum()
    createTable(rows,columns)
})

btnEmptyCell.addEventListener("click", function() 
{
    let rows = rowsNum()
    let columns = columnsNum()
    let cellToDelete = selectCell(rows, columns)

    if (cellToDelete) 
    {
        cellToDelete.innerHTML = " "
        alert("Cell emptied successfully")
    } 
    else 
    {
        alert("Cell not found")
    }
})

btnDeleteCell.addEventListener("click", function() 
{
    let rows = rowsNum()
    let columns = columnsNum()
    let cellToDelete = selectCell(rows, columns)

    if (cellToDelete) 
    {
        cellToDelete.remove()
        alert("Cell deleted successfully")
    } 
    else 
    {
        alert("Cell not found")
    }
})

btnEmptyRow.addEventListener("click", function() 
{
    let rows = rowsNum()
    let rowToEmpty = selectRow(rows)

    if (rowToEmpty) 
    {
        let rowCells = rowToEmpty.children;

        for (let i = 0; i < rowCells.length; i++) 
        {
            rowCells[i].innerHTML = " ";
        }
        alert("Row emptied successfully")
    }
    else 
    {
        alert("Row not found")
    }
})

btnDeleteRow.addEventListener("click", function() 
{
    let rows = rowsNum()
    let rowToDelete = selectRow(rows)

    if (rowToDelete) 
    {
        rowToDelete.remove();
        alert("Row deleted successfully");
    }
    else 
    {
        alert("Row not found")
    }
})

// TODO
btnDeleteColumn.addEventListener("click", function() 
{
    let columns = columnsNum();
    deleteColumn(columns);
    alert("Column deleted successfully");
})