﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data = DataLayer.DataLayer;

namespace BusinessLayer
{
    public class BusinessLayer
    {
        public void makeTable(string filepath)
        {
            Data data = new Data();
            List<string> head = data.readCSVHead(filepath);
            List<List<string>> body = data.readCSVBody(filepath);

            string tableHead = populateTableBodyRow(head, true);
            string tableBody = populateTableBodyRows(body);
            data.writeHTML(makeHTML(joinHeadAndBodyOfTable(tableHead, tableBody)));

        }
        public string makeHTML(string tableContent)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("<html>");
            stringBuilder.AppendLine("<head>");
            stringBuilder.AppendLine("<title> Table </title>");
            stringBuilder.AppendLine("<link rel='stylesheet' type='text/css' href='https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css'");
            stringBuilder.AppendLine("</head>");
            stringBuilder.AppendLine("<body>");
            stringBuilder.AppendLine(tableContent);
            stringBuilder.AppendLine("</body>");
            stringBuilder.AppendLine("</html>");
            return stringBuilder.ToString();

        }
        public string joinHeadAndBodyOfTable(string head, string body)
        {
            StringBuilder table = new StringBuilder();
            table.AppendLine("<table class='table'>");
            table.AppendLine(head);
            table.AppendLine(body);
            table.AppendLine("</table>");
            return table.ToString();
        }
        public string populateTableBodyRows(List<List<string>> rows)
        {
            StringBuilder tableBody = new StringBuilder();
            foreach (List<string> row in rows)
            {

                tableBody.AppendLine(populateTableBodyRow(row, false));
            }
            return tableBody.ToString();
        }
        private string populateTableBodyRow(List<string> row, Boolean isHeader)
        {
            StringBuilder tableBodyRow = new StringBuilder();
            tableBodyRow.AppendLine("<tr>");
            if (isHeader)
            {
                foreach (string cell in row)
                {
                    tableBodyRow.AppendLine(populateTableHeaderCell(cell));
                }
            }
            else
            {
                foreach (string cell in row)
                {
                    tableBodyRow.AppendLine(populateTableBodyCell(cell));
                }
            }
            tableBodyRow.Append("</tr>");
            return tableBodyRow.ToString();
        }
        private string populateTableBodyCell(string cellData)
        {
            StringBuilder tableCell = new StringBuilder();
            tableCell.AppendLine("<td>");
            tableCell.AppendLine(cellData);
            tableCell.AppendLine("</td>");
            return tableCell.ToString();
        }
        private string populateTableHeaderCell(string cellData)
        {
            StringBuilder tableCell = new StringBuilder();
            tableCell.AppendLine("<th>");
            tableCell.AppendLine(cellData);
            tableCell.AppendLine("</th>");
            return tableCell.ToString();
        }

    }
}
