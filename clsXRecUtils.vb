Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices


Public Class clsXRecUtils
        Dim PlanSetDict As DBDictionary
        Dim _nXrecs As Integer

        Public Sub New(ByRef AppName As String)

            RegApp(AppName)
            _nXrecs = countXRecords(AppName)
        End Sub
        Public ReadOnly Property nXrecs() As Integer

            Get
                Return _nXrecs
            End Get
        End Property
        Private Sub RegApp(ByRef AppName As String)
            Dim AppId As ObjectId
            Dim DB As Database = HostApplicationServices.WorkingDatabase
            'get the app table first

            Using docLock As DocumentLock = Application.DocumentManager.MdiActiveDocument.LockDocument()
                Using Trans As Transaction = DB.TransactionManager.StartTransaction()
                    Try
                        Dim AppTable As RegAppTable = Trans.GetObject(DB.RegAppTableId, OpenMode.ForWrite, False, True)
                        If AppTable.Has(AppName) Then
                            AppId = AppTable.Item(AppName)
                        Else
                            'If not, create the Application here.
                            Dim ATR As RegAppTableRecord = New RegAppTableRecord()
                            ATR.Name = AppName
                            AppId = AppTable.Add(ATR)
                            Trans.AddNewlyCreatedDBObject(ATR, True)
                        End If
                        Trans.Commit()
                    Catch aex As Autodesk.AutoCAD.Runtime.Exception
                        MsgBox("AutoCAD Exception: " & aex.Message, MsgBoxStyle.Exclamation)
                    Catch ex As System.Exception
                        MsgBox("System Exception: " & ex.Message, MsgBoxStyle.Exclamation)
                    End Try
                End Using
            End Using
        End Sub
        Private Function countXRecords(ByRef dictName As String) As Integer
            '***This option really counts dictionary entries in the dictionary***
            'return a count of records in the dictionary dictName, and their object

            Dim db As Database = HostApplicationServices.WorkingDatabase

            Using docLock As DocumentLock = Application.DocumentManager.MdiActiveDocument.LockDocument()
                Using trans As Transaction = db.TransactionManager.StartTransaction()
                    Dim NOD As DBDictionary = trans.GetObject(db.NamedObjectsDictionaryId, OpenMode.ForWrite, False)
                    Try
                        PlanSetDict = trans.GetObject(NOD.GetAt(dictName), OpenMode.ForRead, False)
                    Catch
                        PlanSetDict = New DBDictionary()
                        NOD.SetAt(dictName, PlanSetDict)
                        trans.AddNewlyCreatedDBObject(PlanSetDict, True)
                        trans.Commit()
                    Finally
                    End Try
                End Using
            End Using
            Return PlanSetDict.Count
        End Function
        Public Function GetPlanSets() As String()
            Dim KW() As String = {}

            getKeywords(KW)
            Return KW
        End Function
        Private Function getKeywords(ByRef keywords() As String) As Integer
            Dim DE As DictionaryEntry
            Dim nRec, i1 As Integer
            Dim K As String

            nRec = PlanSetDict.Count
            i1 = 0
            ReDim keywords(nRec - 1)
            For Each DE In PlanSetDict
                K = DE.Key
                keywords(i1) = K
                i1 = i1 + 1
            Next
            Return nRec
        End Function
        Public Sub SavePlanSet(ByVal SetName As String, ByVal RB As ResultBuffer)

            addXRecord(APPID, SetName, RB)
        End Sub
        Private Sub addXRecord(ByVal DictName As String, _
            ByRef KeyWord As String, ByRef ResBuf As ResultBuffer)
            'Add or updata the record with the matching keyword
            Dim db As Database = HostApplicationServices.WorkingDatabase
            Dim XRecData As Xrecord

            Using docLock As DocumentLock = Application.DocumentManager.MdiActiveDocument.LockDocument()
                Using trans As Transaction = db.TransactionManager.StartTransaction()
                    Dim NOD As DBDictionary = trans.GetObject(db.NamedObjectsDictionaryId, OpenMode.ForWrite, False)
                    Try
                        PlanSetDict = trans.GetObject(NOD.GetAt(DictName), OpenMode.ForWrite)
                        XRecData = New Xrecord()
                        If ResBuf IsNot Nothing Then
                            XRecData.Data = ResBuf
                        End If
                        PlanSetDict.SetAt(KeyWord, XRecData)
                        trans.AddNewlyCreatedDBObject(XRecData, True)
                        trans.Commit()
                    Catch aex As Autodesk.AutoCAD.Runtime.Exception
                        MsgBox("AutoCAD Exception: " & aex.Message, MsgBoxStyle.Exclamation)
                    Catch ex As System.Exception
                        MsgBox("System Exception: " & ex.Message, MsgBoxStyle.Exclamation)
                    Finally
                    End Try
                End Using
            End Using
        End Sub
        Public Function LoadPlanSet(ByVal SetName As String) As ResultBuffer
            Dim RB As ResultBuffer

            getXRecord(APPID, SetName, RB)
            Return RB
        End Function
        Public Function getXRecord(ByVal DictName As String, _
            ByRef KeyWord As String, ByRef ResBuf As ResultBuffer) As Boolean
            Dim db As Database = HostApplicationServices.WorkingDatabase
            Dim XRecData As Xrecord
            Dim retVal As Boolean = True

            Using docLock As DocumentLock = Application.DocumentManager.MdiActiveDocument.LockDocument()
                Using trans As Transaction = db.TransactionManager.StartTransaction()
                    Dim NOD As DBDictionary = trans.GetObject(db.NamedObjectsDictionaryId, OpenMode.ForWrite, False)
                    Try
                        PlanSetDict = trans.GetObject(NOD.GetAt(DictName), OpenMode.ForRead, False)
                        If PlanSetDict.Contains(KeyWord) Then
                            XRecData = trans.GetObject(PlanSetDict.GetAt(KeyWord), OpenMode.ForRead, False)
                            ResBuf = XRecData.Data
                            retVal = True
                        Else
                            retVal = False
                        End If
                        trans.Commit()
                    Catch aex As Autodesk.AutoCAD.Runtime.Exception
                        MsgBox("AutoCAD Exception: " & aex.Message, MsgBoxStyle.Exclamation)
                    Catch ex As System.Exception
                        MsgBox("System Exception: " & ex.Message, MsgBoxStyle.Exclamation)
                    End Try
                End Using
            End Using
            Return retVal
        End Function
        Public Function getXRecordLength(ByRef DictObj As DBDictionary, ByVal DictName As String, _
            ByRef keyword As String, ByRef xRecordType() As Short, ByRef XRecordData() As Object) As Integer
            ' This returns the type and data as arrays, not a single variant
            Dim i1 As Integer
            Dim db As Database = HostApplicationServices.WorkingDatabase
            Dim XRecData As Xrecord
            Dim ResBuf As ResultBuffer = New ResultBuffer()
            Dim TV As TypedValue = New TypedValue()

            Using docLock As DocumentLock = Application.DocumentManager.MdiActiveDocument.LockDocument()
                Using trans As Transaction = db.TransactionManager.StartTransaction()
                    Dim NOD As DBDictionary = trans.GetObject(db.NamedObjectsDictionaryId, OpenMode.ForWrite, False)
                    Try
                        DictObj = trans.GetObject(NOD.GetAt(DictName), OpenMode.ForRead, False)
                        XRecData = trans.GetObject(DictObj.GetAt(keyword), OpenMode.ForRead, False)
                        ResBuf = XRecData.Data
                        i1 = 0
                        'count the records
                        For Each TV In ResBuf
                            ReDim Preserve xRecordType(i1)
                            ReDim Preserve XRecordData(i1)
                            xRecordType(i1) = ResBuf.AsArray(i1).TypeCode
                            XRecordData(i1) = ResBuf.AsArray(i1).Value
                            i1 = i1 + 1
                        Next
                        trans.Commit()
                    Catch aex As Autodesk.AutoCAD.Runtime.Exception
                        MsgBox("AutoCAD Exception: " & aex.Message, MsgBoxStyle.Exclamation)
                    Catch ex As System.Exception
                        MsgBox("System Exception: " & ex.Message, MsgBoxStyle.Exclamation)
                    End Try
                End Using
            End Using
            Return UBound(xRecordType)
        End Function

        Public Sub removeXRecord(ByRef DictObj As DBDictionary, ByVal DictName As String, ByRef keyword As String)
            'remove the record matching keyword, whether or not it exists

            Dim db As Database = HostApplicationServices.WorkingDatabase

            Using docLock As DocumentLock = Application.DocumentManager.MdiActiveDocument.LockDocument()
                Using trans As Transaction = db.TransactionManager.StartTransaction()
                    Dim NOD As DBDictionary = trans.GetObject(db.NamedObjectsDictionaryId, OpenMode.ForWrite, False)
                    Try
                        DictObj = trans.GetObject(NOD.GetAt(DictName), OpenMode.ForWrite, False)
                        DictObj.Remove(keyword)
                        trans.Commit()
                    Catch aex As Autodesk.AutoCAD.Runtime.Exception
                        MsgBox("AutoCAD Exception: " & aex.Message, MsgBoxStyle.Exclamation)
                    Catch ex As System.Exception
                        MsgBox("System Exception: " & ex.Message, MsgBoxStyle.Exclamation)
                    End Try
                End Using
            End Using
        End Sub
    End Class
