const tableContainer = document.getElementById("table");
const createdTable = createTable(getRowCount(), getColumnCount())
tableContainer.appendChild(createdTable);
    
function createTable(rowCount,columnCount) {
    const table = [] 
    for (let x = 0; x < columnCount; x++) 
    {
        table[x] = []
        for (let y = 0; y < rowCount; y++) 
        {
            addCell(table, x, y);
        }
    }       
return table
}

function addCell(table, x, y) {
    table[x][y] = cell();
}

function cell() {
    return document.createElement("td");
}

function getRowCount() {
               let numberOfRows = parseInt(prompt("Elige el número de filas"))
               return numberOfRows
               }

function getColumnCount() {
                let numberOfColumns = parseInt(prompt("Elige el número de columnas"))
                return numberOfColumns
                }

