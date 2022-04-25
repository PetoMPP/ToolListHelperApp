using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolListHelperLibrary.Models;

namespace ToolListHelperLibrary
{
    public static class ToolListManagerTdmConnector
    {
        public static async Task<ListBrowsingModel> GetListBrowsingModel(string listId)
        {
            using DbConnection connection = TDMConnector.GetTDMConnection();
            ListBrowsingModel model = await connection.QueryFirstAsync<ListBrowsingModel>(new CommandDefinition($@"
SELECT
A.LISTID AS Id,
A.NCPROGRAM AS Name,
A.PARTNAME AS Description,
A.MACHINEID AS Machine,
A.MACHINEGROUPID AS MachineGroup,
A.LISTTYPE AS ListType,
A.MATERIALID AS Material,
A.FIXTURE AS Clamping,
A.WORKPIECEDRAWING AS Drawing,
A.JOBPLAN AS Operation,
A.STATEID1 AS Status1,
A.STATEID2 AS Status2,
A.WORKPIECECLASSID AS WorkpieceClass,
A.USERNAME AS UserName
FROM TDM_LIST AS A
WHERE A.LISTID = '{listId}'",
commandType: System.Data.CommandType.Text));

            model.Tools = (await connection.QueryAsync<ToolData>(new CommandDefinition($@"
SELECT (ISNULL(A.COMPID, A.TOOLID)) AS Id,
(CASE
WHEN A.COMPID IS NULL
THEN C.NAME
ELSE B.NAME
END) AS ItemDescription,
(CASE
WHEN A.COMPID IS NULL
THEN C.NAME2
ELSE B.NAME2
END) AS ItemOrderCode,
A.QUANTITY AS Quantity,
(CASE
WHEN A.COMPID IS NULL
THEN 1
ELSE 0
END) AS ToolType
FROM TDM_LISTLISTB AS A
LEFT JOIN TDM_COMP AS B ON B.COMPID = A.COMPID
LEFT JOIN TDM_TOOL AS C ON C.TOOLID = A.TOOLID
WHERE A.LISTID = '{listId}'",
commandType: System.Data.CommandType.Text))).AsList();

            model.NcProgramFiles = (await connection.QueryAsync<NcProgramFileModel>(new CommandDefinition($@"
SELECT 
A.FILEID AS FileId,
C.MACHINEID AS MachineId,
A.EXTENSION AS Extension, 
A.STATEID AS StateId, 
A.VERSION AS Version,
(SELECT PATH FROM TDM_MACHINESTATEPATH WHERE MACHINEID = C.MACHINEID AND STATEID = A.STATEID) AS Path
FROM NCM_PRODDOCB AS A
JOIN TDM_LIST AS C ON A.FILEID = C.NCPROGRAM
WHERE A.LISTID = '{listId}'
", commandType: System.Data.CommandType.Text))).AsList();

            model.LogEntries = (await connection.QueryAsync<LogEntry>(new CommandDefinition($@"
SELECT 
TIMESTAMP AS CreationTimestamp,
POS AS Position,
USERID AS UserName,
NOTE AS Note
FROM TMS_CHANGEINFO
WHERE ID = '{listId}'", commandType: System.Data.CommandType.Text))).AsList();
            return model;
        }
    }
}
