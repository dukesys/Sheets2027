Imports System.Math

Public Class clsGeoUtils
        Shared Sub lgm015(ByRef x0 As Double, ByRef y0 As Double, ByRef xs As Double, ByRef ys As Double, ByRef xp As Double, ByRef yp As Double, _
                ByRef dis As Double, ByRef Offset As Double)
            Dim dys, dxs, dhs As Double
            Dim dyp, dxp, dhp As Double
            Dim rx, dDis, dOff, rh As Double

            dxs = xs - x0
            dys = ys - y0
            dxp = xp - x0
            dyp = yp - y0
            If Abs(dxs) < 0 Then
                If dys < 0 Then
                    dDis = -dyp
                    dOff = -dxp
                Else
                    dDis = dyp
                    dOff = dxp
                End If
            Else
                dhs = Sqrt(dxs * dxs + dys * dys)
                rx = dxp / dxs
                dhp = rx * dys - dyp
                rh = dhp / dhs
                dOff = rh * dxs
                dDis = rx * dhs - rh * dys
            End If

            dis = dDis
            Offset = dOff
        End Sub
        Shared Function ac2wcb(ByRef Bearing As Double) As Double

            ac2wcb = (0.5 * PI) - Bearing
            If ac2wcb < 0.0# Then
                ac2wcb = ac2wcb + 2 * PI
            End If
        End Function
        Shared Function wcb2ac(ByRef Bearing As Double) As Double

            wcb2ac = PI / 2.0# - Bearing
        End Function
        Shared Sub lgm026(ByRef X As Double, ByRef Y As Double, ByRef WCB As Double, ByRef dis As Double, _
            ByRef x1 As Double, ByRef y1 As Double)

            ' ---- Calculate point x1, y1 based on point x, y, with wcb and dis

            Dim r1, r2 As Double

            r1 = WCB
            r2 = dis
            x1 = X + r2 * System.Math.Sin(r1)
            y1 = Y + r2 * System.Math.Cos(r1)

        End Sub
        Shared Sub lgm016(ByRef X As Double, ByRef Y As Double, ByRef x1 As Double, ByRef y1 As Double, ByRef WCB As Double, ByRef dis As Double)

            ' ---- Calculate distance and wcb of a point x1, y1 from point x, y

            Dim r3, r1, r2, r4 As Double

            r1 = x1 - X
            r2 = y1 - Y
            r4 = lgm018(X, Y, x1, y1)
            If (r4 < ZERTOL) Then
                r3 = ZERO
            Else
                r3 = latan2(r1, r2)
                If r3 < ZERO Then
                    r3 = r3 + TPI
                End If
            End If

            WCB = r3
            dis = r4

        End Sub
        Shared Function lgm018(ByRef X As Double, ByRef Y As Double, ByRef x1 As Double, ByRef y1 As Double) As Double

            ' ---- calculate distance between points

            Dim r2, r1, dis As Double

            r1 = x1 - X
            r2 = y1 - Y
            dis = System.Math.Sqrt(r1 * r1 + r2 * r2)

            lgm018 = dis

        End Function
        Shared Function DTR(ByVal Angle As Double) As Double
            Return (Angle / 180.0) * PI
        End Function
        Shared Function RTD(ByVal Angle As Double) As Double
            Return (180 * (Angle / PI))
        End Function
        Shared Function latan2(ByRef xval As Double, ByRef yval As Double) As Double

            ' ---- Returns value in the range -pi to +pi
            ' ---- unless both arguments are zero,
            ' ---- which returns two pi.

            Dim r1 As Double

            If yval = ZERO Then
                If xval = ZERO Then
                    r1 = TPI
                ElseIf xval > ZERO Then
                    r1 = HPI
                Else
                    r1 = -HPI
                End If
            Else
                r1 = System.Math.Atan(xval / yval)
                If yval < ZERO Then
                    If xval < ZERO Then
                        r1 = r1 - PI
                    Else
                        r1 = r1 + PI
                    End If
                End If
            End If

            latan2 = r1

        End Function
    End Class
