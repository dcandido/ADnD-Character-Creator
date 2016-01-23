Public Class frmMain

    ' Global variables for base attributes
    Public intBaseStr As Integer
    Public intBaseDex As Integer
    Public intBaseCon As Integer
    Public intBaseInt As Integer
    Public intBaseWis As Integer
    Public intBaseCha As Integer

    ' Global variables for attributes
    Public intStr As Integer
    Public intDex As Integer
    Public intCon As Integer
    Public intInt As Integer
    Public intWis As Integer
    Public intCha As Integer

    ' Global variable for selected race
    Public strRace As String

    ' Global variables for statistics
    ' Strength
    Public strHitProb As String
    Public strDmgAdj As String
    Public strWeightAllow As String
    Public strMaxPress As String
    Public strOpenDoors As String
    Public strBendBars As String
    ' Dexterity
    Public strReactAdj As String
    Public strMissileAdj As String
    Public strDefAdj As String
    ' Constitution
    Public strHPadj As String
    Public strSysShock As String
    Public strResurrection As String
    Public strPoisonSave As String
    ' Intelligence
    Public strLanguages As String
    Public strSpellLevel As String
    Public strSpellChance As String
    Public strSpellsPerLevel As String
    Public strIllusionSave As String
    ' Wisdom
    Public strMagDefAdj As String
    Public strBonusSpells As String
    Public strSpellFailure As String
    ' Charisma
    Public strMaxHenchmen As String
    Public strLoyalty As String
    Public strChaReactAdj As String

    ' Structure for warrior saving throws
    Structure Warrior
        Public Const DEATH_SAVE As Integer = 14
        Public Const ITEM_SAVE As Integer = 16
        Public Const POLY_SAVE As Integer = 15
        Public Const BREATH_SAVE As Integer = 17
        Public Const SPELL_SAVE As Integer = 17
    End Structure

    ' Structure for priest saving throws
    Structure Priest
        Public Const DEATH_SAVE As Integer = 10
        Public Const ITEM_SAVE As Integer = 14
        Public Const POLY_SAVE As Integer = 13
        Public Const BREATH_SAVE As Integer = 16
        Public Const SPELL_SAVE As Integer = 15
    End Structure

    ' Structure for rogue saving throws
    Structure Rogue
        Public Const DEATH_SAVE As Integer = 13
        Public Const ITEM_SAVE As Integer = 14
        Public Const POLY_SAVE As Integer = 12
        Public Const BREATH_SAVE As Integer = 16
        Public Const SPELL_SAVE As Integer = 15
    End Structure

    ' Structure for mage saving throws
    Structure Mage
        Public Const DEATH_SAVE As Integer = 14
        Public Const ITEM_SAVE As Integer = 11
        Public Const POLY_SAVE As Integer = 13
        Public Const BREATH_SAVE As Integer = 15
        Public Const SPELL_SAVE As Integer = 12
    End Structure

    Private Sub btnStatroll_Click(sender As System.Object, e As System.EventArgs) Handles btnStatroll.Click
        ' Prepare for rolling
        radHuman.Checked = True
        strRace = "Human"
        btnHProll.Enabled = False
        lblHP.Text = String.Empty
        txtInfo.Text = String.Empty
        Randomize()

        ' Roll 3D6 for Strength
        intBaseStr = CInt(Int(6 * Rnd() + 1)) + CInt(Int(6 * Rnd() + 1)) + CInt(Int(6 * Rnd() + 1))
        lblStr.Text = Convert.ToString(intBaseStr)
        ' Roll 3D6 for Dexterity
        intBaseDex = CInt(Int(6 * Rnd() + 1)) + CInt(Int(6 * Rnd() + 1)) + CInt(Int(6 * Rnd() + 1))
        lblDex.Text = Convert.ToString(intBaseDex)
        ' Roll 3D6 for Constitution
        intBaseCon = CInt(Int(6 * Rnd() + 1)) + CInt(Int(6 * Rnd() + 1)) + CInt(Int(6 * Rnd() + 1))
        lblCon.Text = Convert.ToString(intBaseCon)
        ' Roll 3D6 for Intelligence
        intBaseInt = CInt(Int(6 * Rnd() + 1)) + CInt(Int(6 * Rnd() + 1)) + CInt(Int(6 * Rnd() + 1))
        lblInt.Text = Convert.ToString(intBaseInt)
        ' Roll 3D6 for Wisdom
        intBaseWis = CInt(Int(6 * Rnd() + 1)) + CInt(Int(6 * Rnd() + 1)) + CInt(Int(6 * Rnd() + 1))
        lblWis.Text = Convert.ToString(intBaseWis)
        ' Roll 3D6 for Charisma
        intBaseCha = CInt(Int(6 * Rnd() + 1)) + CInt(Int(6 * Rnd() + 1)) + CInt(Int(6 * Rnd() + 1))
        lblCha.Text = Convert.ToString(intBaseCha)

        ' Allow human race
        radHuman.Enabled = True
        ' Allow dwarf race if eligible
        If intBaseStr >= 8 AndAlso intBaseDex <= 17 AndAlso intBaseCon >= 11 AndAlso intBaseCha <= 17 Then
            radDwarf.Enabled = True
        Else
            radDwarf.Enabled = False
        End If
        ' Allow elf race if eligible
        If intBaseDex >= 6 AndAlso intBaseCon >= 7 AndAlso intBaseInt >= 8 AndAlso intBaseCha >= 8 Then
            radElf.Enabled = True
        Else
            radElf.Enabled = False
        End If
        ' Allow gnome race if eligible
        If intBaseStr >= 6 AndAlso intBaseCon >= 8 AndAlso intBaseInt >= 6 Then
            radGnome.Enabled = True
        Else
            radGnome.Enabled = False
        End If
        ' Allow half-elf race if eligible
        If intBaseDex >= 6 AndAlso intBaseCon >= 6 AndAlso intBaseInt >= 4 Then
            radHalfElf.Enabled = True
        Else
            radHalfElf.Enabled = False
        End If
        ' Allow halfling race if eligible
        If intBaseStr >= 7 AndAlso intBaseDex >= 7 AndAlso intBaseCon >= 10 AndAlso intBaseInt >= 6 Then
            radHalfling.Enabled = True
        Else
            radHalfling.Enabled = False
        End If

        ' Determine and display available classes
        intStr = intBaseStr
        intDex = intBaseDex
        intCon = intBaseCon
        intInt = intBaseInt
        intWis = intBaseWis
        intCha = intBaseCha
        lstClasses.Items.Clear()
        Call findClasses()

        ' List statistics
        Call calculateStatistics()
        Call showStatistics()
    End Sub

    Private Sub calculateStatistics()
        ' Strength
        strHitProb = makePlus(Convert.ToString(getHitProb(intStr)))
        strDmgAdj = makePlus(Convert.ToString(getDmgAdj(intStr)))
        strWeightAllow = Convert.ToString(getWeightAllow(intStr))
        strMaxPress = Convert.ToString(getMaxPress(intStr))
        strOpenDoors = Convert.ToString(getOpenDoors(intStr))
        strBendBars = Convert.ToString(getBendBars(intStr))

        ' Dexterity
        strReactAdj = makePlus(Convert.ToString(getDexAdj(intDex)))
        strMissileAdj = strReactAdj
        strDefAdj = makePlus(Convert.ToString(getDefAdj(intDex)))

        ' Constitution
        strHPadj = makePlus(Convert.ToString(getHPadj(intCon)))
        If strHPadj = "+3" Then
            strHPadj = "+2(+3 for Warrior)"
        ElseIf strHPadj = "+4" Then
            strHPadj = "+2(+4 for Warrior)"
        ElseIf strHPadj = "+5" Then
            strHPadj = "+2(+5 for Warrior)"
        End If
        strSysShock = Convert.ToString(getSysShock(intCon))
        strResurrection = Convert.ToString(getResurrection(intCon))
        strPoisonSave = makePlus(Convert.ToString(getPoisonSave(intCon)))

        ' Intelligence
        strLanguages = Convert.ToString(getLanguages(intInt))
        strSpellLevel = Convert.ToString(getSpellLevel(intInt))
        strSpellChance = Convert.ToString(getSpellChance(intInt))
        strSpellsPerLevel = Convert.ToString(getSpellsPerLevel(intInt))
        If strSpellsPerLevel = "-1" Then
            strSpellsPerLevel = "All"
        End If
        strIllusionSave = Convert.ToString(getIllusionSave(intInt))
        If strIllusionSave = "0" Then
            strIllusionSave = "None"
        Else
            strIllusionSave = "1st-level"
        End If

        ' Wisdom
        strMagDefAdj = makePlus(Convert.ToString(getMagDefAdj(intWis)))
        strBonusSpells = Convert.ToString(getBonusSpells(intWis))
        If strBonusSpells = "1" Then
            strBonusSpells = "1 1st"
        ElseIf strBonusSpells = "11" Then
            strBonusSpells = "2 1st"
        ElseIf strBonusSpells = "112" Then
            strBonusSpells = "2 1st, 1 2nd"
        ElseIf strBonusSpells = "1122" Then
            strBonusSpells = "2 1st, 2 2nd"
        ElseIf strBonusSpells = "11223" Then
            strBonusSpells = "2 1st, 2 2nd, 1 3rd"
        ElseIf strBonusSpells = "112234" Then
            strBonusSpells = "2 1st, 2 2nd, 1 3rd, 1 4th"
        End If
        strSpellFailure = Convert.ToString(getSpellFailure(intWis))

        ' Charisma
        strMaxHenchmen = Convert.ToString(getMaxHenchmen(intCha))
        strLoyalty = makePlus(Convert.ToString(getLoyalty(intCha)))
        strChaReactAdj = makePlus(Convert.ToString(getChaReactAdj(intCha)))
    End Sub

    Private Sub showStatistics()
        txtInfo.Text = String.Empty

        ' Strength
        txtInfo.Text = txtInfo.Text & "Hit Probability: " & strHitProb
        txtInfo.Text = txtInfo.Text & Environment.NewLine & "Damage Adjustment: " & strDmgAdj
        txtInfo.Text = txtInfo.Text & Environment.NewLine & "Weight Allowance: " & strWeightAllow & " pounds"
        txtInfo.Text = txtInfo.Text & Environment.NewLine & "Maximum Press: " & strMaxPress & " pounds"
        txtInfo.Text = txtInfo.Text & Environment.NewLine & "Open Doors: " & strOpenDoors & " (in 20)"
        txtInfo.Text = txtInfo.Text & Environment.NewLine & "Bend Bars/Lift Gates: " & strBendBars & "%"

        ' Dexterity
        txtInfo.Text = txtInfo.Text & Environment.NewLine
        txtInfo.Text = txtInfo.Text & Environment.NewLine & "Reaction Adjustment (DEX): " & strReactAdj
        txtInfo.Text = txtInfo.Text & Environment.NewLine & "Missile Attack Adjustment: " & strMissileAdj
        txtInfo.Text = txtInfo.Text & Environment.NewLine & "Defensive Adjustment: " & strDefAdj & " (+ is bad)"

        ' Constitution
        txtInfo.Text = txtInfo.Text & Environment.NewLine
        txtInfo.Text = txtInfo.Text & Environment.NewLine & "Hit Point Adjustment: " & strHPadj
        txtInfo.Text = txtInfo.Text & Environment.NewLine & "System Shock: " & strSysShock & "%"
        txtInfo.Text = txtInfo.Text & Environment.NewLine & "Resurrection Survival: " & strResurrection & "%"
        txtInfo.Text = txtInfo.Text & Environment.NewLine & "Poison Save: " & strPoisonSave

        ' Intelligence
        txtInfo.Text = txtInfo.Text & Environment.NewLine
        txtInfo.Text = txtInfo.Text & Environment.NewLine & "Number of Languages: " & strLanguages
        txtInfo.Text = txtInfo.Text & Environment.NewLine & "Spell Level: " & strSpellLevel
        txtInfo.Text = txtInfo.Text & Environment.NewLine & "Chance to Learn Spell: " & strSpellChance & "%"
        txtInfo.Text = txtInfo.Text & Environment.NewLine & "Maximum Number of Spells per Level: " & strSpellsPerLevel
        txtInfo.Text = txtInfo.Text & Environment.NewLine & "Spell Immunity: " & strIllusionSave

        ' Wisdom
        txtInfo.Text = txtInfo.Text & Environment.NewLine
        txtInfo.Text = txtInfo.Text & Environment.NewLine & "Magical Defense Adjustment: " & strMagDefAdj
        txtInfo.Text = txtInfo.Text & Environment.NewLine & "Bonus Spells: " & strBonusSpells & " (Priest only)"
        txtInfo.Text = txtInfo.Text & Environment.NewLine & "Chance of Spell Failure: " & strSpellFailure & "% (Priest only)"

        ' Charisma
        txtInfo.Text = txtInfo.Text & Environment.NewLine
        txtInfo.Text = txtInfo.Text & Environment.NewLine & "Maximum Number of Henchmen: " & strMaxHenchmen
        txtInfo.Text = txtInfo.Text & Environment.NewLine & "Loyalty Base: " & strLoyalty
        txtInfo.Text = txtInfo.Text & Environment.NewLine & "Reaction Adjustment (CHA): " & strChaReactAdj
    End Sub

    Private Function getChaReactAdj(ByRef intCharisma) As Integer
        If intCharisma = 2 Then
            Return -6
        ElseIf intCharisma = 3 Then
            Return -5
        ElseIf intCharisma = 4 Then
            Return -4
        ElseIf intCharisma = 5 Then
            Return -3
        ElseIf intCharisma = 6 Then
            Return -2
        ElseIf intCharisma = 7 Then
            Return -1
        ElseIf intCharisma >= 8 AndAlso intCharisma <= 12 Then
            Return 0
        ElseIf intCharisma = 13 Then
            Return 1
        ElseIf intCharisma = 14 Then
            Return 2
        ElseIf intCharisma = 15 Then
            Return 3
        ElseIf intCharisma = 16 Then
            Return 5
        ElseIf intCharisma = 17 Then
            Return 6
        ElseIf intCharisma = 18 Then
            Return 7
        Else
            Return 0
        End If
    End Function

    Private Function getLoyalty(ByRef intCharisma) As Integer
        If intCharisma = 2 Then
            Return -7
        ElseIf intCharisma = 3 Then
            Return -6
        ElseIf intCharisma = 4 Then
            Return -5
        ElseIf intCharisma = 5 Then
            Return -4
        ElseIf intCharisma = 6 Then
            Return -3
        ElseIf intCharisma = 7 Then
            Return -2
        ElseIf intCharisma = 8 Then
            Return -1
        ElseIf intCharisma >= 9 AndAlso intCharisma <= 13 Then
            Return 0
        ElseIf intCharisma = 14 Then
            Return 1
        ElseIf intCharisma = 15 Then
            Return 3
        ElseIf intCharisma = 16 Then
            Return 4
        ElseIf intCharisma = 17 Then
            Return 8
        ElseIf intCharisma = 18 Then
            Return 6
        Else
            Return 0
        End If
    End Function

    Private Function getMaxHenchmen(ByRef intCharisma) As Integer
        If intCharisma >= 2 AndAlso intCharisma <= 4 Then
            Return 1
        ElseIf intCharisma >= 5 AndAlso intCharisma <= 6 Then
            Return 2
        ElseIf intCharisma >= 7 AndAlso intCharisma <= 8 Then
            Return 3
        ElseIf intCharisma >= 9 AndAlso intCharisma <= 11 Then
            Return 4
        ElseIf intCharisma >= 12 AndAlso intCharisma <= 13 Then
            Return 5
        ElseIf intCharisma = 14 Then
            Return 6
        ElseIf intCharisma = 15 Then
            Return 7
        ElseIf intCharisma = 16 Then
            Return 8
        ElseIf intCharisma = 17 Then
            Return 10
        ElseIf intCharisma = 18 Then
            Return 15
        Else
            Return 0
        End If
    End Function

    Private Function getSpellFailure(ByRef intWisdom) As Integer
        If intWisdom = 2 Then
            Return 60
        ElseIf intWisdom = 3 Then
            Return 50
        ElseIf intWisdom = 4 Then
            Return 45
        ElseIf intWisdom = 5 Then
            Return 40
        ElseIf intWisdom = 6 Then
            Return 35
        ElseIf intWisdom = 7 Then
            Return 30
        ElseIf intWisdom = 8 Then
            Return 25
        ElseIf intWisdom = 9 Then
            Return 20
        ElseIf intWisdom = 10 Then
            Return 15
        ElseIf intWisdom = 11 Then
            Return 10
        ElseIf intWisdom = 12 Then
            Return 5
        Else
            Return 0
        End If
    End Function

    Private Function getBonusSpells(ByRef intWisdom) As Integer
        If intWisdom >= 2 AndAlso intWisdom <= 12 Then
            Return 0
        ElseIf intWisdom = 13 Then
            Return 1
        ElseIf intWisdom = 14 Then
            Return 11
        ElseIf intWisdom = 15 Then
            Return 112
        ElseIf intWisdom = 16 Then
            Return 1122
        ElseIf intWisdom = 17 Then
            Return 11223
        ElseIf intWisdom = 18 Then
            Return 112234
        Else
            Return 0
        End If
    End Function

    Private Function getMagDefAdj(ByRef intWisdom) As Integer
        If intWisdom = 2 Then
            Return -4
        ElseIf intWisdom = 3 Then
            Return -3
        ElseIf intWisdom = 4 Then
            Return -2
        ElseIf intWisdom >= 5 AndAlso intWisdom <= 7 Then
            Return -1
        ElseIf intWisdom >= 8 AndAlso intWisdom <= 14 Then
            Return 0
        ElseIf intWisdom = 15 Then
            Return 1
        ElseIf intWisdom = 16 Then
            Return 2
        ElseIf intWisdom = 17 Then
            Return 3
        ElseIf intWisdom = 18 Then
            Return 4
        Else
            Return 0
        End If
    End Function

    Private Function getIllusionSave(ByRef intIntelligence) As Integer
        If intIntelligence = 19 Then
            Return 1
        Else
            Return 0
        End If
    End Function

    Private Function getSpellsPerLevel(ByRef intIntelligence) As Integer
        If intIntelligence >= 3 AndAlso intIntelligence <= 8 Then
            Return 0
        ElseIf intIntelligence = 9 Then
            Return 6
        ElseIf intIntelligence >= 10 AndAlso intIntelligence <= 12 Then
            Return 7
        ElseIf intIntelligence >= 13 AndAlso intIntelligence <= 14 Then
            Return 9
        ElseIf intIntelligence >= 15 AndAlso intIntelligence <= 16 Then
            Return 11
        ElseIf intIntelligence = 17 Then
            Return 14
        ElseIf intIntelligence = 18 Then
            Return 18
        ElseIf intIntelligence = 19 Then
            ' Infinite
            Return -1
        Else
            Return 0
        End If
    End Function

    Private Function getSpellChance(ByRef intIntelligence) As Integer
        If intIntelligence >= 3 AndAlso intIntelligence <= 8 Then
            Return 0
        ElseIf intIntelligence = 9 Then
            Return 35
        ElseIf intIntelligence = 10 Then
            Return 40
        ElseIf intIntelligence = 11 Then
            Return 45
        ElseIf intIntelligence = 12 Then
            Return 50
        ElseIf intIntelligence = 13 Then
            Return 55
        ElseIf intIntelligence = 14 Then
            Return 60
        ElseIf intIntelligence = 15 Then
            Return 65
        ElseIf intIntelligence = 16 Then
            Return 70
        ElseIf intIntelligence = 17 Then
            Return 75
        ElseIf intIntelligence = 18 Then
            Return 85
        ElseIf intIntelligence = 19 Then
            Return 95
        Else
            Return 0
        End If
    End Function

    Private Function getSpellLevel(ByRef intIntelligence) As Integer
        If intIntelligence >= 3 AndAlso intIntelligence <= 8 Then
            Return 0
        ElseIf intIntelligence = 9 Then
            Return 4
        ElseIf intIntelligence >= 10 AndAlso intIntelligence <= 11 Then
            Return 5
        ElseIf intIntelligence >= 12 AndAlso intIntelligence <= 13 Then
            Return 6
        ElseIf intIntelligence >= 14 AndAlso intIntelligence <= 15 Then
            Return 7
        ElseIf intIntelligence >= 16 AndAlso intIntelligence <= 17 Then
            Return 8
        ElseIf intIntelligence >= 18 AndAlso intIntelligence <= 19 Then
            Return 9
        Else
            Return 0
        End If
    End Function

    Private Function getLanguages(ByRef intIntelligence) As Integer
        If intIntelligence >= 3 AndAlso intIntelligence <= 8 Then
            Return 1
        ElseIf intIntelligence >= 9 AndAlso intIntelligence <= 11 Then
            Return 2
        ElseIf intIntelligence >= 12 AndAlso intIntelligence <= 13 Then
            Return 3
        ElseIf intIntelligence >= 14 AndAlso intIntelligence <= 15 Then
            Return 4
        ElseIf intIntelligence = 16 Then
            Return 5
        ElseIf intIntelligence = 17 Then
            Return 6
        ElseIf intIntelligence = 18 Then
            Return 7
        ElseIf intIntelligence = 19 Then
            Return 8
        Else
            Return 0
        End If
    End Function

    Private Function getPoisonSave(ByRef intConstitution) As Integer
        ' Dwarves and halflings use a special chart
        If radDwarf.Checked = True OrElse radHalfling.Checked = True Then
            If intConstitution >= 4 AndAlso intConstitution <= 6 Then
                Return 1
            ElseIf intConstitution >= 7 AndAlso intConstitution <= 10 Then
                Return 2
            ElseIf intConstitution >= 11 AndAlso intConstitution <= 13 Then
                Return 3
            ElseIf intConstitution >= 14 AndAlso intConstitution <= 17 Then
                Return 4
            ElseIf intConstitution >= 18 AndAlso intConstitution <= 19 Then
                Return 5
            Else
                Return 0
            End If
            ' Everyone else uses this chart
        Else
            If intConstitution = 2 Then
                Return -1
            ElseIf intConstitution >= 3 AndAlso intConstitution <= 18 Then
                Return 0
            ElseIf intConstitution = 19 Then
                Return 1
            Else
                Return 0
            End If
        End If
    End Function

    Private Function getResurrection(ByRef intConstitution) As Integer
        If intConstitution = 2 Then
            Return 35
        ElseIf intConstitution = 3 Then
            Return 40
        ElseIf intConstitution = 4 Then
            Return 45
        ElseIf intConstitution = 5 Then
            Return 50
        ElseIf intConstitution = 6 Then
            Return 55
        ElseIf intConstitution = 7 Then
            Return 60
        ElseIf intConstitution = 8 Then
            Return 65
        ElseIf intConstitution = 9 Then
            Return 70
        ElseIf intConstitution = 10 Then
            Return 75
        ElseIf intConstitution = 11 Then
            Return 80
        ElseIf intConstitution = 12 Then
            Return 85
        ElseIf intConstitution = 13 Then
            Return 90
        ElseIf intConstitution = 14 Then
            Return 92
        ElseIf intConstitution = 15 Then
            Return 94
        ElseIf intConstitution = 16 Then
            Return 96
        ElseIf intConstitution = 17 Then
            Return 98
        ElseIf intConstitution >= 18 AndAlso intConstitution <= 19 Then
            Return 100
        Else
            Return 0
        End If
    End Function

    Private Function getSysShock(ByRef intConstitution) As Integer
        If intConstitution = 2 Then
            Return 30
        ElseIf intConstitution = 3 Then
            Return 35
        ElseIf intConstitution = 4 Then
            Return 40
        ElseIf intConstitution = 5 Then
            Return 45
        ElseIf intConstitution = 6 Then
            Return 50
        ElseIf intConstitution = 7 Then
            Return 55
        ElseIf intConstitution = 8 Then
            Return 60
        ElseIf intConstitution = 9 Then
            Return 65
        ElseIf intConstitution = 10 Then
            Return 70
        ElseIf intConstitution = 11 Then
            Return 75
        ElseIf intConstitution = 12 Then
            Return 80
        ElseIf intConstitution = 13 Then
            Return 85
        ElseIf intConstitution = 14 Then
            Return 88
        ElseIf intConstitution = 15 Then
            Return 90
        ElseIf intConstitution = 16 Then
            Return 95
        ElseIf intConstitution = 17 Then
            Return 97
        ElseIf intConstitution >= 18 AndAlso intConstitution <= 19 Then
            Return 99
        Else
            Return 0
        End If
    End Function

    Private Function getHPadj(ByRef intConstitution) As Integer
        If intConstitution >= 2 AndAlso intConstitution <= 3 Then
            Return -2
        ElseIf intConstitution >= 4 AndAlso intConstitution <= 6 Then
            Return -1
        ElseIf intConstitution >= 7 AndAlso intConstitution <= 14 Then
            Return 0
        ElseIf intConstitution = 15 Then
            Return 1
        ElseIf intConstitution = 16 Then
            Return 2
        ElseIf intConstitution = 17 Then
            Return 3
        ElseIf intConstitution = 18 Then
            Return 4
        ElseIf intConstitution = 19 Then
            Return 5
        Else
            Return 0
        End If
    End Function

    Private Function makePlus(ByVal oldString) As String
        If oldString >= 0 Then
            Return "+" & oldString
        Else
            Return oldString
        End If
    End Function

    Private Function getDefAdj(ByRef intDexterity) As Integer
        If intDexterity = 3 Then
            Return 4
        ElseIf intDexterity = 4 Then
            Return 3
        ElseIf intDexterity = 5 Then
            Return 2
        ElseIf intDexterity = 6 Then
            Return 1
        ElseIf intDexterity >= 7 AndAlso intDexterity <= 14 Then
            Return 0
        ElseIf intDexterity = 15 Then
            Return -1
        ElseIf intDexterity = 16 Then
            Return -2
        ElseIf intDexterity = 17 Then
            Return -3
        ElseIf intDexterity >= 18 AndAlso intDexterity <= 19 Then
            Return -4
        Else
            Return 0
        End If
    End Function

    Private Function getDexAdj(ByRef intDexterity) As Integer
        If intDexterity = 3 Then
            Return -3
        ElseIf intDexterity = 4 Then
            Return -2
        ElseIf intDexterity = 5 Then
            Return -1
        ElseIf intDexterity >= 6 AndAlso intDexterity <= 15 Then
            Return 0
        ElseIf intDexterity = 16 Then
            Return 1
        ElseIf intDexterity >= 17 AndAlso intDexterity <= 18 Then
            Return 2
        ElseIf intDexterity = 19 Then
            Return 3
        Else
            Return 0
        End If
    End Function

    Private Function getBendBars(ByRef intStrength) As Integer
        If intStrength >= 2 AndAlso intStrength <= 7 Then
            Return 0
        ElseIf intStrength >= 8 AndAlso intStrength <= 9 Then
            Return 1
        ElseIf intStrength >= 10 AndAlso intStrength <= 11 Then
            Return 2
        ElseIf intStrength >= 12 AndAlso intStrength <= 13 Then
            Return 4
        ElseIf intStrength >= 14 AndAlso intStrength <= 15 Then
            Return 7
        ElseIf intStrength = 16 Then
            Return 10
        ElseIf intStrength = 17 Then
            Return 13
        ElseIf intStrength = 18 Then
            Return 16
        Else
            Return 0
        End If
    End Function

    Private Function getOpenDoors(ByRef intStrength) As Integer
        If intStrength = 2 Then
            Return 1
        ElseIf intStrength = 3 Then
            Return 2
        ElseIf intStrength >= 4 AndAlso intStrength <= 5 Then
            Return 3
        ElseIf intStrength >= 6 AndAlso intStrength <= 7 Then
            Return 4
        ElseIf intStrength >= 8 AndAlso intStrength <= 9 Then
            Return 5
        ElseIf intStrength >= 10 AndAlso intStrength <= 11 Then
            Return 6
        ElseIf intStrength >= 12 AndAlso intStrength <= 13 Then
            Return 7
        ElseIf intStrength >= 14 AndAlso intStrength <= 15 Then
            Return 8
        ElseIf intStrength = 16 Then
            Return 9
        ElseIf intStrength = 17 Then
            Return 10
        ElseIf intStrength = 18 Then
            Return 11
        Else
            Return 0
        End If
    End Function

    Private Function getMaxPress(ByRef intStrength) As Integer
        If intStrength = 2 Then
            Return 5
        ElseIf intStrength = 3 Then
            Return 10
        ElseIf intStrength >= 4 AndAlso intStrength <= 5 Then
            Return 25
        ElseIf intStrength >= 6 AndAlso intStrength <= 7 Then
            Return 55
        ElseIf intStrength >= 8 AndAlso intStrength <= 9 Then
            Return 90
        ElseIf intStrength >= 10 AndAlso intStrength <= 11 Then
            Return 115
        ElseIf intStrength >= 12 AndAlso intStrength <= 13 Then
            Return 140
        ElseIf intStrength >= 14 AndAlso intStrength <= 15 Then
            Return 170
        ElseIf intStrength = 16 Then
            Return 195
        ElseIf intStrength = 17 Then
            Return 220
        ElseIf intStrength = 18 Then
            Return 255
        Else
            Return 0
        End If
    End Function

    Private Function getWeightAllow(ByRef intStrength) As Integer
        If intStrength = 2 Then
            Return 1
        ElseIf intStrength = 3 Then
            Return 5
        ElseIf intStrength >= 4 AndAlso intStrength <= 5 Then
            Return 10
        ElseIf intStrength >= 6 AndAlso intStrength <= 7 Then
            Return 20
        ElseIf intStrength >= 8 AndAlso intStrength <= 9 Then
            Return 35
        ElseIf intStrength >= 10 AndAlso intStrength <= 11 Then
            Return 40
        ElseIf intStrength >= 12 AndAlso intStrength <= 13 Then
            Return 45
        ElseIf intStrength >= 14 AndAlso intStrength <= 15 Then
            Return 55
        ElseIf intStrength = 16 Then
            Return 70
        ElseIf intStrength = 17 Then
            Return 85
        ElseIf intStrength = 18 Then
            Return 110
        Else
            Return 0
        End If
    End Function

    Private Function getDmgAdj(ByRef intStrength) As Integer
        If intStrength = 2 Then
            Return -2
        ElseIf intStrength >= 3 AndAlso intStrength <= 5 Then
            Return -1
        ElseIf intStrength >= 16 AndAlso intStrength <= 17 Then
            Return 1
        ElseIf intStrength = 18 Then
            Return 2
        Else
            Return 0
        End If
    End Function

    Private Function getHitProb(ByRef intStrength) As Integer
        If intStrength >= 2 AndAlso intStrength <= 3 Then
            Return -3
        ElseIf intStrength >= 4 AndAlso intStrength <= 5 Then
            Return -2
        ElseIf intStrength >= 6 AndAlso intStrength <= 7 Then
            Return -1
        ElseIf intStrength >= 17 AndAlso intStrength <= 18 Then
            Return 1
        Else
            Return 0
        End If
    End Function

    Private Sub findClasses()
        ' If the character is a human
        If radHuman.Checked = True Then
            ' Check for fighter eligibility
            If intStr >= 9 Then
                lstClasses.Items.Add("Fighter")
                ' Check for paladin eligibility
                If intStr >= 12 AndAlso intCon >= 9 AndAlso intWis >= 13 AndAlso intCha >= 17 Then
                    lstClasses.Items.Add("Paladin")
                End If
                ' Check for ranger eligibility
                If intStr >= 13 AndAlso intCon >= 14 AndAlso intWis >= 14 AndAlso intDex >= 13 Then
                    lstClasses.Items.Add("Ranger")
                End If
            End If

            ' Check for mage eligibility
            If intInt >= 9 Then
                lstClasses.Items.Add("Mage")
                ' Check for abjurer eligibility
                If intWis > 15 Then
                    lstClasses.Items.Add("Abjurer")
                    ' Check for diviner and necromancer eligibility
                    If intWis > 16 Then
                        lstClasses.Items.Add("Diviner")
                        lstClasses.Items.Add("Necromancer")
                    End If
                End If
                ' Check for conjurer eligibility
                If intCon > 15 Then
                    lstClasses.Items.Add("Conjurer")
                    ' Check for invoker eligibility
                    If intCon > 16 Then
                        lstClasses.Items.Add("Invoker")
                    End If
                End If
                ' Check for enchanter eligibility
                If intCha > 16 Then
                    lstClasses.Items.Add("Enchanter")
                End If
                ' Check for transmuter eligibility
                If intDex > 15 Then
                    lstClasses.Items.Add("Transmuter")
                    ' Check for illusionist eligibility
                    If intDex > 16 Then
                        lstClasses.Items.Add("Illusionist")
                    End If
                End If
            End If

            ' Check for cleric eligibility
            If intWis >= 9 Then
                lstClasses.Items.Add("Cleric")
                ' Check for druid eligibility
                If intWis >= 12 AndAlso intCha >= 15 Then
                    lstClasses.Items.Add("Druid")
                End If
            End If

            ' Check for thief eligibility
            If intDex >= 9 Then
                lstClasses.Items.Add("Thief")
                ' Check for bard eligibility
                If intDex >= 12 AndAlso intInt >= 13 AndAlso intCha >= 15 Then
                    lstClasses.Items.Add("Bard")
                End If
            End If
        End If

        ' If the character is a dwarf
        If radDwarf.Checked = True Then
            ' Check for fighter eligibility
            If intStr >= 9 Then
                lstClasses.Items.Add("Fighter")
            End If

            ' Check for cleric eligibility
            If intWis >= 9 Then
                lstClasses.Items.Add("Cleric")
            End If

            ' Check for thief eligibility
            If intDex >= 9 Then
                lstClasses.Items.Add("Thief")
            End If
        End If

        ' If the character is a elf
        If radElf.Checked = True Then
            ' Check for fighter eligibility
            If intStr >= 9 Then
                lstClasses.Items.Add("Fighter")
                ' Check for ranger eligibility
                If intStr >= 13 AndAlso intCon >= 14 AndAlso intWis >= 14 AndAlso intDex >= 13 Then
                    lstClasses.Items.Add("Ranger")
                End If
            End If

            ' Check for mage eligibility
            If intInt >= 9 Then
                lstClasses.Items.Add("Mage")
                ' Check for diviner eligibility
                If intWis > 16 Then
                    lstClasses.Items.Add("Diviner")
                End If
                ' Check for enchanter eligibility
                If intCha > 16 Then
                    lstClasses.Items.Add("Enchanter")
                End If
            End If

            ' Check for cleric eligibility
            If intWis >= 9 Then
                lstClasses.Items.Add("Cleric")
            End If

            ' Check for thief eligibility
            If intDex >= 9 Then
                lstClasses.Items.Add("Thief")
            End If
        End If

        ' If the character is a gnome
        If radGnome.Checked = True Then
            ' Check for fighter eligibility
            If intStr >= 9 Then
                lstClasses.Items.Add("Fighter")
            End If

            ' Check for illusionist eligibility
            If intInt >= 9 AndAlso intDex >= 16 Then
                lstClasses.Items.Add("Illusionist")
            End If

            ' Check for cleric eligibility
            If intWis >= 9 Then
                lstClasses.Items.Add("Cleric")
            End If

            ' Check for thief eligibility
            If intDex >= 9 Then
                lstClasses.Items.Add("Thief")
            End If
        End If

        ' If the character is a half-elf
        If radHalfElf.Checked = True Then
            ' Check for fighter eligibility
            If intStr >= 9 Then
                lstClasses.Items.Add("Fighter")
                ' Check for ranger eligibility
                If intStr >= 13 AndAlso intCon >= 14 AndAlso intWis >= 14 AndAlso intDex >= 13 Then
                    lstClasses.Items.Add("Ranger")
                End If
            End If

            ' Check for mage eligibility
            If intInt >= 9 Then
                lstClasses.Items.Add("Mage")
                ' Check for diviner eligibility
                If intWis > 16 Then
                    lstClasses.Items.Add("Diviner")
                End If
                ' Check for conjurer eligibility
                If intCon > 15 Then
                    lstClasses.Items.Add("Conjurer")
                End If
                ' Check for enchanter eligibility
                If intCha > 16 Then
                    lstClasses.Items.Add("Enchanter")
                End If
                ' Check for transmuter eligibility
                If intDex > 15 Then
                    lstClasses.Items.Add("Transmuter")
                End If
            End If

            ' Check for cleric eligibility
            If intWis >= 9 Then
                lstClasses.Items.Add("Cleric")
                ' Check for druid eligibility
                If intWis >= 12 AndAlso intCha >= 15 Then
                    lstClasses.Items.Add("Druid")
                End If
            End If

            ' Check for thief eligibility
            If intDex >= 9 Then
                lstClasses.Items.Add("Thief")
                ' Check for bard eligibility
                If intDex >= 12 AndAlso intInt >= 13 AndAlso intCha >= 15 Then
                    lstClasses.Items.Add("Bard")
                End If
            End If
        End If

        ' If the character is a halfling
        If radHalfling.Checked = True Then
            ' Check for fighter eligibility
            If intStr >= 9 Then
                lstClasses.Items.Add("Fighter")
            End If

            ' Check for cleric eligibility
            If intWis >= 9 Then
                lstClasses.Items.Add("Cleric")
            End If

            ' Check for thief eligibility
            If intDex >= 9 Then
                lstClasses.Items.Add("Thief")
            End If
        End If
    End Sub

    Private Sub showStats()
        ' Display stats
        lblStr.Text = Convert.ToString(intStr)
        lblDex.Text = Convert.ToString(intDex)
        lblCon.Text = Convert.ToString(intCon)
        lblInt.Text = Convert.ToString(intInt)
        lblWis.Text = Convert.ToString(intWis)
        lblCha.Text = Convert.ToString(intCha)
    End Sub

    Private Sub showSavingThrows(ByVal strStruct)
        txtClassInfo.Text = txtClassInfo.Text & Environment.NewLine & "Paralyzation, Poison, Death Magic: " & Convert.ToString(strStruct.DEATH_SAVE)
        txtClassInfo.Text = txtClassInfo.Text & Environment.NewLine & "Rod, Staff, Wand: " & Convert.ToString(strStruct.ITEM_SAVE)
        txtClassInfo.Text = txtClassInfo.Text & Environment.NewLine & "Petrification, Polymorph: " & Convert.ToString(strStruct.POLY_SAVE)
        txtClassInfo.Text = txtClassInfo.Text & Environment.NewLine & "Breath Weapon: " & Convert.ToString(strStruct.BREATH_SAVE)
        txtClassInfo.Text = txtClassInfo.Text & Environment.NewLine & "Spell: " & Convert.ToString(strStruct.SPELL_SAVE)
    End Sub

    Private Sub showAllSavingThrows(ByVal strClass As String)
        txtClassInfo.Text = "Unmodified Saving Throws"
        ' Determine the class and show the appropriate saving throws
        If strClass = "Fighter" OrElse strClass = "Ranger" OrElse strClass = "Paladin" Then
            Dim warrior As Warrior
            Call showSavingThrows(warrior)
        ElseIf strClass = "Cleric" OrElse strClass = "Druid" Then
            Dim priest As Priest
            Call showSavingThrows(priest)
        ElseIf strClass = "Thief" OrElse strClass = "Bard" Then
            Dim rogue As Rogue
            Call showSavingThrows(rogue)
        ElseIf strClass = "Mage" OrElse strClass = "Abjurer" OrElse strClass = "Conjurer" OrElse strClass = "Invoker" OrElse
               strClass = "Conjurer" OrElse strClass = "Diviner" OrElse strClass = "Enchanter" OrElse
               strClass = "Illusionist" OrElse strClass = "Necromancer" OrElse strClass = "Transmuter" Then
            Dim mage As Mage
            Call showSavingThrows(mage)
        End If
        txtClassInfo.Text = txtClassInfo.Text & Environment.NewLine
    End Sub

    Private Sub showThiefChances(ByVal strRace As String, ByVal intDexterity As Integer)

        ' Initialize variables for thief skills with the base values
        Dim intPickPockets As Integer = 15
        Dim intOpenLocks As Integer = 10
        Dim intTraps As Integer = 5
        Dim intMoveSilent As Integer = 10
        Dim intHide As Integer = 5
        Dim intDetect As Integer = 15
        Dim intClimb As Integer = 60
        Dim intRead As Integer = 0

        ' Adjust for dexterity
        If intDexterity = 9 Then
            intPickPockets -= 15
            intOpenLocks -= 10
            intTraps -= 10
            intMoveSilent -= 20
            intHide -= 10
        ElseIf intDexterity = 10 Then
            intPickPockets -= 10
            intOpenLocks -= 5
            intTraps -= 10
            intMoveSilent -= 15
            intHide -= 5
        ElseIf intDexterity = 11 Then
            intPickPockets -= 5
            intTraps -= 5
            intMoveSilent -= 10
        ElseIf intDexterity = 12 Then
            intMoveSilent -= 5
        ElseIf intDexterity = 16 Then
            intOpenLocks += 5
        ElseIf intDexterity = 17 Then
            intPickPockets += 5
            intOpenLocks += 10
            intMoveSilent += 5
            intHide += 5
        ElseIf intDexterity = 18 Then
            intPickPockets += 10
            intOpenLocks += 15
            intTraps += 5
            intMoveSilent += 10
            intHide += 10
        ElseIf intDexterity = 19 Then
            intPickPockets += 15
            intOpenLocks += 20
            intTraps += 10
            intMoveSilent += 15
            intHide += 15
        End If

        ' Adjust for race
        If strRace = "Dwarf" Then
            intOpenLocks += 10
            intTraps += 15
            intClimb -= 10
            intRead -= 5
        ElseIf strRace = "Elf" Then
            intPickPockets += 5
            intOpenLocks -= 5
            intMoveSilent += 5
            intHide += 10
            intDetect += 5
        ElseIf strRace = "Gnome" Then
            intOpenLocks += 5
            intTraps += 10
            intMoveSilent += 5
            intHide += 5
            intDetect += 10
            intClimb -= 15
        ElseIf strRace = "Half-Elf" Then
            intPickPockets += 10
            intHide += 5
        ElseIf strRace = "Halfling" Then
            intPickPockets += 5
            intOpenLocks += 5
            intTraps += 5
            intMoveSilent += 10
            intHide += 15
            intDetect += 5
            intClimb -= 15
            intRead -= 5
        End If

        ' Display results
        txtClassInfo.Text = txtClassInfo.Text & Environment.NewLine & "Rogue Skills"
        txtClassInfo.Text = txtClassInfo.Text & Environment.NewLine & "Pick Pockets: " & Convert.ToString(intPickPockets) & "%"
        txtClassInfo.Text = txtClassInfo.Text & Environment.NewLine & "Open Locks: " & Convert.ToString(intOpenLocks) & "%"
        txtClassInfo.Text = txtClassInfo.Text & Environment.NewLine & "Find/Remove Traps: " & Convert.ToString(intTraps) & "%"
        txtClassInfo.Text = txtClassInfo.Text & Environment.NewLine & "Move Silently: " & Convert.ToString(intMoveSilent) & "%"
        txtClassInfo.Text = txtClassInfo.Text & Environment.NewLine & "Hide in Shadows: " & Convert.ToString(intHide) & "%"
        txtClassInfo.Text = txtClassInfo.Text & Environment.NewLine & "Detect Noise: " & Convert.ToString(intDetect) & "%"
        txtClassInfo.Text = txtClassInfo.Text & Environment.NewLine & "Climb Walls: " & Convert.ToString(intClimb) & "%"
        txtClassInfo.Text = txtClassInfo.Text & Environment.NewLine & "Read Languages: " & Convert.ToString(intRead) & "%"
    End Sub

    Private Sub showBardChances(ByVal strRace As String, ByVal intDexterity As Integer)
        ' Initialize variables for bard skills with the base values
        Dim intPickPockets As Integer = 10
        Dim intDetect As Integer = 20
        Dim intClimb As Integer = 50
        Dim intRead As Integer = 5

        ' Adjust for dexterity
        If intDexterity = 9 Then
            intPickPockets -= 15
        ElseIf intDexterity = 10 Then
            intPickPockets -= 10
        ElseIf intDexterity = 11 Then
            intPickPockets -= 5
        ElseIf intDexterity = 17 Then
            intPickPockets += 5
        ElseIf intDexterity = 18 Then
            intPickPockets += 10
        ElseIf intDexterity = 19 Then
            intPickPockets += 15
        End If

        ' Adjust for race
        If strRace = "Dwarf" Then
            intClimb -= 10
            intRead -= 5
        ElseIf strRace = "Elf" Then
            intPickPockets += 5
            intDetect += 5
        ElseIf strRace = "Gnome" Then
            intDetect += 10
            intClimb -= 15
        ElseIf strRace = "Half-elf" Then
            intPickPockets += 10
        ElseIf strRace = "Halfling" Then
            intPickPockets += 5
            intDetect += 5
            intClimb -= 15
            intRead -= 5
        End If

        ' Display results
        txtClassInfo.Text = txtClassInfo.Text & Environment.NewLine & "Rogue Skills"
        txtClassInfo.Text = txtClassInfo.Text & Environment.NewLine & "Pick Pockets: " & Convert.ToString(intPickPockets) & "%"
        txtClassInfo.Text = txtClassInfo.Text & Environment.NewLine & "Detect Noise: " & Convert.ToString(intDetect) & "%"
        txtClassInfo.Text = txtClassInfo.Text & Environment.NewLine & "Climb Walls: " & Convert.ToString(intClimb) & "%"
        txtClassInfo.Text = txtClassInfo.Text & Environment.NewLine & "Read Languages: " & Convert.ToString(intRead) & "%"
    End Sub

    Private Sub radDwarf_Click(sender As Object, e As System.EventArgs) Handles radDwarf.Click
        ' Adjust stats for dwarf race
        intStr = intBaseStr
        intDex = intBaseDex
        intCon = intBaseCon + 1
        intInt = intBaseInt
        intWis = intBaseWis
        intCha = intBaseCha - 1
        ' Display stats
        showStats()
        ' Determine and display available classes
        lstClasses.Items.Clear()
        Call findClasses()
        btnHProll.Enabled = False
        lblHP.Text = String.Empty
        txtClassInfo.Text = String.Empty
        ' List statistics
        Call calculateStatistics()
        Call showStatistics()
        ' Set race to dwarf
        strRace = "Dwarf"
    End Sub

    Private Sub radElf_Click(sender As Object, e As System.EventArgs) Handles radElf.Click
        ' Adjust stats for elf race
        intStr = intBaseStr
        intDex = intBaseDex + 1
        intCon = intBaseCon - 1
        intInt = intBaseInt
        intWis = intBaseWis
        intCha = intBaseCha
        ' Display stats
        showStats()
        ' Determine and display available classes
        lstClasses.Items.Clear()
        Call findClasses()
        btnHProll.Enabled = False
        lblHP.Text = String.Empty
        txtClassInfo.Text = String.Empty
        ' List statistics
        Call calculateStatistics()
        Call showStatistics()
        ' Set race to elf
        strRace = "Elf"
    End Sub

    Private Sub radGnome_Click(sender As Object, e As System.EventArgs) Handles radGnome.Click
        ' Adjust stats for gnome race
        intStr = intBaseStr
        intDex = intBaseDex
        intCon = intBaseCon
        intInt = intBaseInt + 1
        intWis = intBaseWis - 1
        intCha = intBaseCha
        ' Display stats
        showStats()
        ' Determine and display available classes
        lstClasses.Items.Clear()
        Call findClasses()
        btnHProll.Enabled = False
        lblHP.Text = String.Empty
        txtClassInfo.Text = String.Empty
        ' List statistics
        Call calculateStatistics()
        Call showStatistics()
        ' Set race to gnome
        strRace = "Gnome"
    End Sub

    Private Sub radHalfElf_Click(sender As Object, e As System.EventArgs) Handles radHalfElf.Click
        ' Adjust stats for half-elf race
        intStr = intBaseStr
        intDex = intBaseDex
        intCon = intBaseCon
        intInt = intBaseInt
        intWis = intBaseWis
        intCha = intBaseCha
        ' Display stats
        showStats()
        ' Determine and display available classes
        lstClasses.Items.Clear()
        Call findClasses()
        btnHProll.Enabled = False
        lblHP.Text = String.Empty
        txtClassInfo.Text = String.Empty
        ' List statistics
        Call calculateStatistics()
        Call showStatistics()
        ' Set race to half-elf
        strRace = "Half-Elf"
    End Sub

    Private Sub radHalfling_Click(sender As Object, e As System.EventArgs) Handles radHalfling.Click
        ' Adjust stats for halfling race
        intStr = intBaseStr - 1
        intDex = intBaseDex + 1
        intCon = intBaseCon
        intInt = intBaseInt
        intWis = intBaseWis
        intCha = intBaseCha
        ' Display stats
        showStats()
        ' Determine and display available classes
        lstClasses.Items.Clear()
        Call findClasses()
        btnHProll.Enabled = False
        lblHP.Text = String.Empty
        txtClassInfo.Text = String.Empty
        ' List statistics
        Call calculateStatistics()
        Call showStatistics()
        ' Set race to halfling
        strRace = "Halfling"
    End Sub

    Private Sub radHuman_Click(sender As Object, e As System.EventArgs) Handles radHuman.Click
        ' Adjust stats for human race
        intStr = intBaseStr
        intDex = intBaseDex
        intCon = intBaseCon
        intInt = intBaseInt
        intWis = intBaseWis
        intCha = intBaseCha
        ' Display stats
        showStats()
        ' Determine and display available classes
        lstClasses.Items.Clear()
        Call findClasses()
        btnHProll.Enabled = False
        lblHP.Text = String.Empty
        txtClassInfo.Text = String.Empty
        ' List statistics
        Call calculateStatistics()
        Call showStatistics()
        ' Set race to human
        strRace = "Human"
    End Sub

    Private Sub lstClasses_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lstClasses.SelectedIndexChanged
        ' If the user clicks a class, enable rolling for HP and clear any HP rolled
        btnHProll.Enabled = True
        lblHP.Text = String.Empty
        ' Also show saving throws
        Call showAllSavingThrows(lstClasses.SelectedItem)
        ' If the class selected is thief, show thief skills
        If lstClasses.SelectedItem = "Thief" Then
            showThiefChances(strRace, intDex)
        End If
    End Sub

    Private Sub btnHProll_Click(sender As Object, e As System.EventArgs) Handles btnHProll.Click
        ' Determine the size of the dice to roll for HP
        Dim maxHP As Integer
        If lstClasses.SelectedItem = "Fighter" OrElse lstClasses.SelectedItem = "Paladin" OrElse lstClasses.SelectedItem = "Ranger" Then
            maxHP = 10
        ElseIf lstClasses.SelectedItem = "Cleric" OrElse lstClasses.SelectedItem = "Druid" Then
            maxHP = 8
        ElseIf lstClasses.SelectedItem = "Thief" OrElse lstClasses.SelectedItem = "Bard" Then
            maxHP = 6
        ElseIf lstClasses.SelectedItem = "Mage" OrElse lstClasses.SelectedItem = "Abjurer" OrElse lstClasses.SelectedItem = "Conjurer" OrElse lstClasses.SelectedItem = "Invoker" OrElse
               lstClasses.SelectedItem = "Conjurer" OrElse lstClasses.SelectedItem = "Diviner" OrElse lstClasses.SelectedItem = "Enchanter" OrElse
               lstClasses.SelectedItem = "Illusionist" OrElse lstClasses.SelectedItem = "Necromancer" OrElse lstClasses.SelectedItem = "Transmuter" Then
            maxHP = 4
        End If
        ' Roll the dice and display the result
        lblHP.Text = Convert.ToString(CInt(Int(maxHP * Rnd() + 1)))
    End Sub
End Class
