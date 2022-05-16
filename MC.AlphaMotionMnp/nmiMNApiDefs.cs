/******************************************************************************
*
*	File Version: 1,0,1,1
*
*	Copyright(c) 2012 Alpha Motion Co,. Ltd. All Rights Reserved.
*
*	This file is strictly confidential and do not distribute it outside.
*
*	MODULE NAME :
*		nmiMApiDefs.cs
*
*	AUTHOR :
*		K.C. Lee
*
*	DESCRIPTION :
*		the header file for RC files of project.
*
*
* - Phone: +82-31-303-5050
* - Fax  : +82-31-303-5051
* - URL  : http://www.alphamotion.co.kr,
*
*
/****************************************************************************/


using System;
using System.Text;


public sealed class nmiMNApiDefs
{
    // Device ID definition //
    public const int TMC_BB8MNP = 0xD8;
    public const int TMC_BB4MNP = 0xD4;
    public const int TMC_BB0MNP = 0xD0;           

    public const int TMC_BA800P	= 0xB8;     
    public const int TMC_BA600P = 0xB6;
    public const int TMC_BA400P = 0xB4;
    public const int TMC_BA200P = 0xB2;
    
    public const int TMC_BB160P = 0xCF;
    public const int TMC_BB120P = 0xCC;

    public const int TMC_BB800P = 0xC8;
    public const int TMC_BB400P = 0xC4;

    public const int TMC_BB8MNFPX = 0x38;
    public const int TMC_BB4MNFPX = 0x34;
    public const int TMC_BB0MNFPX = 0x30;


    public const int TMC_BB8MNFP = 0x28;
    public const int TMC_BB4MNFP = 0x24;
    public const int TMC_BB0MNFP = 0x20;

    public const int TMC_BB800FP = 0x18;
    public const int TMC_BB400FP = 0x14;

    // PCIe Device ID definition //
    public const int TMC_BB8MNPE = 0xB8;
    public const int TMC_BB6MNPE = 0xB6;
    public const int TMC_BB4MNPE = 0xB4;
    public const int TMC_BB2MNPE = 0xB2;
    public const int TMC_BB0MNPE = 0xB0;

    public const int TMC_BB8MNPEX = 0xE8;
    public const int TMC_BB6MNPEX = 0xE6;
    public const int TMC_BB4MNPEX = 0xE4;
    public const int TMC_BB2MNPEX = 0xE2;
    public const int TMC_BB0MNPEX = 0xE0;

    public const int TMC_BB160PE = 0xFC;
    public const int TMC_BB120PE = 0xFA;
    public const int TMC_BB800PE = 0xF8;
    public const int TMC_BB400PE = 0xF4;
    public const int TMC_BB200PE = 0xF2;
   
    // Definition of maximum number of things //

    //Device Max
    public const int TMC_MAX_MOT_DEV = 8;  // Maximum number of Motion Devices in one PC
    public const int TMC_MAX_MOT_AXES = 8;  // Maximum number of motion axes

    
    public const int TMC_MAX_DI	=					 48; // Maximum number of D/I channels
    public const int TMC_MAX_DO =                    48; // Maximum number of D/O channels

    public const int TMC_MAX_STR = 256; //Maximum String Length

    // RING Max
    public const int TMC_MAX_RING_DEC = 2; // Maximum number of Ring in one Motion-Net		

    public const int TMC_MAX_SLAVE_DEC = 64; // Maximum number of Slave Device in one Motion-Net        

    // Motion Chip Registers //
    public enum MP_REG {	
          MSTS  =  0, RMV,   PRMV,  RFL,   PRFL,  RFH,   PRFH,  RUR,   PRUR,  RDR,   PRDR,  RMG,   PRMG,  RDP,   PRDP, 
          RMD   = 15, PRMD,  RIP,   PRIP,  RUS,   PRUS,  RDS,   PRDS,  RFA,   RENV1, RENV2, RENV3, RENV4, RENV5, RENV6, RENV7, 
          RCUN1 = 31, RCUN2, RCUN3, RCUN4, RCMP1, RCMP2, RCMP3, RCMP4, RCMP5, PRCP5, RIRQ,  RLTC1, RLTC2, RLTC3, RLTC4, 
          RSTS  = 46, REST,  RIST,  RPLS,  RSPD,  RPSDC, RCI, RIPS,  RCIC,
          RFCUN = 55, RFSER, RFSMR, RFGER0, RFGMR0, RFGER1, RFGMR1, RFGER2, RFGMR2, RFGER3, RFGMR3
    };

    public const int emDIO	=                   0;
    public const int emMOT  =                   1;

    // Axis index definition //
    public const int emAX0	=					0;
    public const int emAX1	=					1;
    public const int emAX2	=					2;
    public const int emAX3	=					3;
    public const int emAX4	=					4;
    public const int emAX5	=					5;
    public const int emAX6	=					6;
    public const int emAX7	=					7;
    public const int emAX8  =                   8;
    public const int emAX9  =                   9;
    public const int emAXA  =                   10;
    public const int emAXB  =                   11;
    public const int emAXC  =                   12;
    public const int emAXD  =                   13;
    public const int emAXE  =                   14;
    public const int emAXF  =                   15;

    // Definition for axes mask  //
    public const int emAX0_MASK =				0x00000001;
    public const int emAX1_MASK =				0x00000002;
    public const int emAX2_MASK =				0x00000004;
    public const int emAX3_MASK =				0x00000008;
    public const int emAX4_MASK =				0x00000010;
    public const int emAX5_MASK =				0x00000020;
    public const int emAX6_MASK =				0x00000040;
    public const int emAX7_MASK =				0x00000080;
    public const int emAX8_MASK =               0x00000100;
    public const int emAX9_MASK =               0x00000200;
    public const int emAXA_MASK =               0x00000400;
    public const int emAXB_MASK =               0x00000800;
    public const int emAXC_MASK =               0x00001000;
    public const int emAXD_MASK =               0x00002000;
    public const int emAXE_MASK =               0x00004000;
    public const int emAXF_MASK =               0x00008000;

    // Definition for axes mask  //
    public const int emGAX0_BIT = 				0x00000000;
    public const int emGAX1_BIT =				0x00000001;
    public const int emGAX2_BIT =				0x00000002;
    public const int emGAX3_BIT =				0x00000003;
    public const int emGAX4_BIT =				0x00000004;
    public const int emGAX5_BIT =				0x00000005;
    public const int emGAX6_BIT =				0x00000006;
    public const int emGAX7_BIT =				0x00000007;
    public const int emGMPG_BIT =				0x00000008;
    public const int emGPAB_BIT =               0x00000009;
     
    public const int emBIT_OFF =                0;
    public const int emBIT_ON =                 1;

    public const int emOFF =                    0;
    public const int emON =                     1;

    // Boolean type definition //
    public const int emFALSE =                  0;
    public const int emTRUE =                   1;

    // Used type definition //
    public const int emNOTUSED =                0;
    public const int emUSED =                   1;

    public const int emDISABLED =			    0;
    public const int emENABLED	= 				1;

    
    // Used type definition //
    public const int emLOW =                    0;
    public const int emHIGH =                   1;

    // Used type definition //
    public const int emLOGIC_A	=				0;
    public const int emLOGIC_B	=				1;

    // motion type definition 
    public const int emSTAND =                  0; /*steady*/
    public const int emRUNNING =                1; /*running*/

    
    // stop type definition //
    public const int emESTOP =                  0;
    public const int emSSTOP =                  1;
    public const int emSTOP  = 					1;

    //Operation direction 
    public const int emDIR_P =                  0; /*(+)Dir*/
    public const int emDIR_N =                  1; /*(-)Dir*/

    
    // speed profile type definition //
    public const int emPROF_C =                 0; //Constant Speed Profile
    public const int emPROF_T =                 1; //Trapezoidal Speed Profile
    public const int emPROF_S =                 2; //S-Curve Speed Profile
    public const int emPROF_N =                 3; //Curve Speed Profile

    // speed profile type definition 
    public const int emCONST =                  0;
    public const int emTCURVE =                 1;
    public const int emSCURVE =                 2;
    public const int emNCURVE =                 3;

    public const int emINC =                    0; /*Relative*/ 
    public const int emABS =                    1; /*Absolute*/
    
    // Arc operation direction //
    public const int emCW =                    	0; //Clockwise Direction         ( Angle Decreases  < 0)
    public const int emCCW =                    1; //Counter Clockwise Direction ( Angle Increases  > 0)

    public const int emOPEN_LOOP =              0; //OPEN CLOSE LOOP
    public const int emSEMI_LOOP =              1; //SEMI CLOSE LOOP
    public const int emFULL_LOOP =              2; //FULL CLOSE LOOP(���� ����)

    // Bit order of pmiAxGetMechanical() return value  //
    public const int emMEC_S_EMG    =				0x000000001; // EMG �Է� ��ȣ ����
    public const int emMEC_S_ALM    =				0x000000002; // �˶� �Է� ��ȣ ����
    public const int emMEC_S_ELP    =  				0x000000004; // POSITIVE ����Ʈ ����ġ �Է� ��ȣ ����
    public const int emMEC_S_ELN    =				0x000000008; // NEGATIVE ����Ʈ ����ġ �Է� ��ȣ ����
    public const int emMEC_S_ORG    =				0x000000010; // ORIGIN ����ġ �Է� ��ȣ ����
    public const int emMEC_S_DIR    =				0x000000020; // ���� ���� ���� ( 0 : +���� , 1 : -����) 
    public const int emMEC_S_OK	    =				0x000000040; // HOME_OK �Է� ��ȣ ����
    public const int emMEC_S_PCS    =				0x000000080; // PCS �Է� ��ȣ ����
    public const int emMEC_S_CRC    =				0x000000100; // CRC ��� ��ȣ ����
    public const int emMEC_S_EZ     =				0x000000200; // EZ �Է� ��ȣ ����
    public const int emMEC_S_CLR    = 				0x000000400; // CLR �Է� ��ȣ ����
    public const int emMEC_S_LTC    =				0x000000800; // LATCH �Է� ��ȣ ����
    public const int emMEC_S_SD     =				0x000001000; // SLOW DOWN �Է� ��ȣ ����
    public const int emMEC_S_INP    =				0x000002000; // IN-POSITION �Է� ��ȣ ����
    public const int emMEC_S_SVON   =				0x000004000; //SVON ��ȣ ����
    public const int emMEC_S_ARST   =				0x000008000; //SERVO ALARM RESET ��ȣ ����
    public const int emMEC_S_STA    =				0x000010000; // STA �Է� ��ȣ ����
    public const int emMEC_S_STP    =				0x000020000; // STP �Է� ��ȣ ����
    public const int emMEC_S_ESYNC  = 				0x000040000; // SYNC ���� �Է� ��ȣ ����
    public const int emMEC_S_EGANT  =				0x000080000; // GANTRY ���� ���� �Է� ��ȣ ����
    public const int emMEC_S_DRV  	=				0x000100000; // ������
    public const int emMEC_S_CMP  	=				0x000200000; // ��ġ�� �����
    public const int emMEC_S_SYNC  	=				0x000400000; // SYNC �����
    public const int emMEC_S_GANT  	=				0x000800000; // GANTRY �����
        

    public const int  emDRV_STOP 	=				0x00000001; // ��� ���� ��
    public const int  emWAIT_DR 	=				0x00000002; // DR �Է� ��ȣ ��ٸ�
    public const int  emWAIT_STA 	=  				0x00000004; // STA �Է� ��ȣ ��ٸ�
    public const int  emWAIT_INSYNC =				0x00000008; // ���� ���� ��ȣ ��ٸ�
    public const int  emWAIT_OTHER 	=				0x00000010; // Ÿ�� ���� ��ȣ ��ٸ�
    public const int  emWAIT_CRC 	=				0x00000020; // CRC ��� �Ϸ� ��ٸ�
    public const int  emWAIT_DIR 	=				0x00000040; // ���� ��ȭ�� ��ٸ�
    public const int  emBACKLASH 	=				0x00000080; // BACKLASH ����
    public const int  emWAIT_MPG 	=				0x00000100; // PA/PB �Է� ��ȣ ��ٸ�
    public const int  emIN_FA 		=				0x00000200; // FA ���� ���� �� ( Ȩ ����� �ӵ� )
    public const int  emIN_FL 		= 				0x00000400; // FL ���� ���� ��
    public const int  emIN_FUR 		=				0x00000800; // ���� ��
    public const int  emIN_FH 		=				0x00001000; // FH ���� ���� �� 
    public const int  emIN_FDR 		=				0x00002000; // ���� �� 
    public const int  emWAIT_INP 	=				0x00004000; // INP �Է� ��ȣ ��ٸ�
                                    				
    // LEVEL type definition //     				
    public const int emLEVEL_LOW =  				0;
    public const int emLEVEL_HIGH =  				1;
                                    				
    // stp stop type definition //  				
    public const int emSTP_NSTOP =  				0;
    public const int emSTP_ESTOP =  				1;
    public const int emSTP_SSTOP =  				2;

    //soft limit action
    public const int emSOFT_NONE =                  0;
    public const int emSOFT_ESTOP =                 1;
    public const int emSOFT_SSTOP =                 2;
    public const int emSOFT_CHVEL =                 3;

    // remain pulse stop type definition //
    public const int emAUTO =                       0;
    public const int emMANUAL =                     1;

    public const int emSD_INIT =				    0; 
    public const int emSD_STOP =					1;
    public const int emSD_LATCH =                   0;

    public const int emERR_NONE =                   0; /*������� ����*/ 
    public const int emERR_ESTOP =                  1; /*��   ����*/
    public const int emERR_SSTOP =                  2; /*���� ����*/
    public const int emERR_CHGVEL =                 3; /*�ӵ� ����*/

    // Encoder input mode definition //
    public const int emEAB1X =                      0x00;
    public const int emEAB2X =                      0x01;
    public const int emEAB4X =                      0x02;
    public const int emCWCCW =                      0x03;

    
    //  PA/PB input mode definition //
    public const int emPAB1X =                      0x00;
    public const int emPAB2X =                      0x01;
    public const int emPAB4X =                      0x02;
    public const int emPCWCCW =                     0x03;

    // Command output mode definition //
    public const int emONE_LOW_HIGH_LOW =           0x00; 
    public const int emONE_HIGH_HIGH_LOW =          0x01; 
    public const int emONE_LOW_LOW_HIGH =           0x02; 
    public const int emONE_HIGH_LOW_HIGH =          0x03; 
    public const int emTWO_CW_CCW_LOW =             0x04; 
    public const int emTWO_CW_CCW_HIGH =            0x05; 
    public const int emTWO_CCW_CW_LOW =             0x06; 
    public const int emTWO_CCW_CW_HIGH =            0x07; 
    public const int emTWO_PHASE =                  0x08; 
    public const int emTWO_PHASE_RESERVE =          0x09;

    public const int emCOMM =                       0;/*Command*/
    public const int emFEED =                       1;/*Feedback*/
   
    public const int emEQ_PDIR =                    0;//CmpData = CmpSrc_Value ( while counting up )
    public const int emEQ_NDIR =                    1;// CmpData = CmpSrc_Value ( while counting down )

    // sta method definition //
    public const int emSTA_SOFTWARE =               0;/*Software */
    public const int emSTA_HARDWARE =               1;/* Hardware*/

    // sta action definition //
    public const int emACT_LEVEL =                  0;/* Level Trigger */
    public const int emACT_FALL =                   1;/* Edge Trigger*/

    // Compare Type //
    public const int emCMP_IDX0 =                   0;/*compare[0]*/
    public const int emCMP_IDX1 =                   1;/*compare[1]*/
    public const int emCMP_IDX2 =                   2;/*compare[2]*/
    public const int emCMP_IDX3 =                   3;/*compare[3]*/

    // Gantry Type //
    public const int emGANT_IDX0 =                  0;/*Gantry[0]*/
    public const int emGANT_IDX1 =                  1;/*Gantry[1]*/
    public const int emGANT_IDX2 =                  2;/*Gantry[2]*/
    public const int emGANT_IDX3 =                  3;/*Gantry[3]*/

    // motion type definition //
    public const int emFORWARD =                    0;/*forward*/
    public const int emRESERVE =                    1;/*reserved*/

    // Action when general comparator met the condition //
    public const int emEVT_ONLY =                   0;// ���ͷ�Ʈ�� �߻�
    public const int emEVT_ESTOP =                  1;// ���ͷ�Ʈ �� �� ����
    public const int emEVT_STOP =                   2;// ���ͷ�Ʈ �� ������ ����
    public const int emEVT_SPDCHG =                 3;// ���ͷ�Ʈ �� �ӵ�����

    // Backlash/Slip correction mode //
    public const int emCORR_DIS =                   0;// Disable correction
    public const int emCORR_BACK =                  1;// Backlash correction mode
    public const int emCORR_SLIP =                  2;// Slip correction mode

    //position trigger output level
    public const int emRISING =                     0;
    public const int emFALLING =                    1;

    // Interrupt Handler Type //
    public const int emIHT_MESSAGE =                0;
    public const int emIHT_CALLBACK =               1;
    public const int emIHT_EVENT =                  2;

    // SetFilterAB�� ��� //
    
    public const int emPULSAR_AB =                  0;
    public const int emENC_AB =                     1;

    public const int emHOME_POS_RST0 =              0;// ORG(/EL/EZ) ��ȣ�� �߻��� �� COMMAND & FEEDBACK ��ġ�� 0���� Ŭ�����Ѵ�.
    public const int emHOME_POS_RST1 =              1;// �������͸� ��� �Ϸ��ϰ� ���� COMMAND & FEEDBACK ��ġ�� ��� 0���� Ŭ�����Ѵ�.
    public const int emHOME_POS_RST2 =              2;// �������͸� ��� �Ϸ��ϰ� ���� FEEDBACK ��ġ�� �״�� �ΰ� COMMAND ��ġ�� FEEDBACK ��ġ�� ��ġ��Ų��.

    public const int emHOME_NG =                     0;  	// �������͸� ���������� �Ϸ����� ����
    public const int emHOME_OK =                     1;	// �������͸� ���������� �Ϸ���.

    // Sync mode //
    public const int emSYNC_DISABLE =               0;
    public const int emSYNC_INT_SYNC =              1;
    public const int emSYNC_OTHER_STOP =            2;

    // Internal sync. conditions //
    public const int emISYNC_ACC_STA =              1;// 0: at start of acceleration
    public const int emISYNC_ACC_END =              2;// 1: at end of acceleration
    public const int emISYNC_DEC_STA =              3;// 2: at start of deceleration
    public const int emISYNC_DEC_END =              4;// 3: at end of deceleration
    public const int emISYNC_SLN =                  5;// 4: when (-)software limit met
    public const int emISYNC_SLP =                  6;// 5: when (+)software limit met
    public const int emISYNC_GCMP =                 7;// 6: when General Comparator condition is satisfied
    public const int emISYNC_TCMP =                 8;// 7: when Trigger Comparator condition is satisfied

    //Coordinate Systems
    public const int emMAX_CS =                     4;//Maximum Number of Coordinate Systems

    //Coordinate System No.
    public const int emCS0 =                        0;
    public const int emCS1 =                        1;
    public const int emCS2 =                        2;
    public const int emCS3 =                        3;

    //Coordinate System No.
    public const int emHEL0 = 0;
    public const int emHEL1 = 1;
    public const int emHEL2 = 2;
    public const int emHEL3 = 3;

    //Coordinate System Mask
    public const int emCS0_MASK =                   0x00000001; 
    public const int emCS1_MASK =                   0x00000002; 
    public const int emCS2_MASK =                   0x00000004; 
    public const int emCS3_MASK =                   0x00000008; 
    public const int emCS4_MASK =                   0x00000010; 
    public const int emCS5_MASK =                   0x00000020; 
    public const int emCS6_MASK =                   0x00000040; 
    public const int emCS7_MASK =                   0x00000080;
    public const int emCS8_MASK =                   0x00000100;
    public const int emCS9_MASK =                   0x00000200;
    public const int emCSA_MASK =                   0x00000400;
    public const int emCSB_MASK =                   0x00000800;
    public const int emCSC_MASK =                   0x00001000;
    public const int emCSD_MASK =                   0x00002000;
    public const int emCSE_MASK =                   0x00004000;
    public const int emCSF_MASK =                   0x00008000;

    // Internal sync. conditions //
    public const int emCNS_VECTOR =                 0;//0:Vector Vel
    public const int emCNS_MASTER =                 1;//1:Long Axis Vel

    // Function Log Level //
    public const int emDLOG_NONE =                  0;   //LOG ��� ���� ����
    public const int emDLOG_ERROR_ONLY=             1;   //������ �߻��� ��� 
    public const int emDLOG_MOT_SET	=               2;   //��� ���� �Լ� + ���� �Լ�(SET)  
    public const int emDLOG_DO_SET	=               3;   //LEVEL 2 + ��ȯ �Լ�(SET) + ������ ��� �Լ�(DO)
    public const int emDLOG_DI_SET	=               4;   //LEVEL 3 + ������ �Է� �Լ�(DI) 
    public const int emDLOG_ALL	=                   5;   //����

    // Motion net
    public const int emCOMM_SPEED2_5 =	            0;// 2.5Mbps ��� �ӵ�  
    public const int emCOMM_SPEED5 =		        1;// 5Mbps   ��� �ӵ�   
    public const int emCOMM_SPEED10	=	            2;// 10Mbps  ��� �ӵ�  
    public const int emCOMM_SPEED20 =               3;// 25Mbps  ��� �ӵ�

    //�����̺� �߿��� SB-MN16GPIO-M ��ǰ 
    public const int emNONE_DIO =                   0;//  ��� ����
    public const int emONLY_DI =                    1;//  �Է� ���� 
    public const int emONLY_DO =                    2;//  ��� ����

    // =======================================
    // == IO Bit
    // =======================================
    public const int TMC_BIT_OFF =                  0;
    public const int TMC_BIT_ON =                   1;

    // Boolean type definition //
    public const int TMC_FALSE =        			0;
    public const int TMC_TRUE =			            1;

    // Used type definition //
    public const int TMC_NOTUSED =                  0;
    public const int TMC_USED =                     1;

    // Used type definition //
    public const int TMC_LOW =                      0;
    public const int TMC_HIGH =                     1;

    // Axis index definition //
    public const int TMC_AX0 =					    0;
    public const int TMC_AX1 =					    1;
    public const int TMC_AX2 =					    2;
    public const int TMC_AX3 =					    3;
    public const int TMC_AX4 =					    4;
    public const int TMC_AX5 =					    5;
    public const int TMC_AX6 =					    6;
    public const int TMC_AX7 =					    7;
    public const int TMC_AX8 =                      8;
    public const int TMC_AX9 =                      9;
    public const int TMC_AXA =                      10;
    public const int TMC_AXB =                      11;
    public const int TMC_AXC =                      12;
    public const int TMC_AXD =                      13;
    public const int TMC_AXE =                      14;
    public const int TMC_AXF =                      15;

    // Definition for axes mask  //
    public const int TMC_AX0_MASK 	=				0x00000001;
    public const int TMC_AX1_MASK 	=				0x00000002;
    public const int TMC_AX2_MASK 	=				0x00000004;
    public const int TMC_AX3_MASK 	=				0x00000008;
    public const int TMC_AX4_MASK 	=				0x00000010;
    public const int TMC_AX5_MASK 	=				0x00000020;
    public const int TMC_AX6_MASK 	=				0x00000040;
    public const int TMC_AX7_MASK 	=				0x00000080;
    public const int TMC_AX8_MASK   =               0x00000100;
    public const int TMC_AX9_MASK   =               0x00000200;
    public const int TMC_AXA_MASK   =               0x00000400;
    public const int TMC_AXB_MASK   =               0x00000800;
    public const int TMC_AXC_MASK   =               0x00001000;
    public const int TMC_AXD_MASK   =               0x00002000;
    public const int TMC_AXE_MASK   =               0x00004000;
    public const int TMC_AXF_MASK   =               0x00008000;

    public const int TMC_OPEN_LOOP	=				0;   //OPEN CLOSE LOOP
    public const int TMC_SEMI_LOOP	=				1;   //SEMI CLOSE LOOP
    public const int TMC_FULL_LOOP	=				2;   //FULL CLOSE LOOP(���� ����)


    // Bit order of TMCAxGetMechanical() return value  //
    public const int TMC_MST_EMG 		=			0x000000001; // EMG �Է� ��ȣ ����
    public const int TMC_MST_ALM 		=			0x000000002; // �˶� �Է� ��ȣ ����
    public const int TMC_MST_ELP  		=			0x000000004; // POSITIVE ����Ʈ ����ġ �Է� ��ȣ ����
    public const int TMC_MST_ELN  		=			0x000000008; // NEGATIVE ����Ʈ ����ġ �Է� ��ȣ ����
    public const int TMC_MST_ORG  		=			0x000000010; // ORIGIN ����ġ �Է� ��ȣ ����
    public const int TMC_MST_DIR 		=			0x000000020; // ���� ���� ���� ( 0 : +���� , 1 : -����) 
    public const int TMC_MST_OK 		=			0x000000040; // HOME_OK �Է� ��ȣ ����
    public const int TMC_MST_PCS 		=			0x000000080; // PCS �Է� ��ȣ ����
    public const int TMC_MST_CRC  		=			0x000000100; // CRC ��� ��ȣ ����
    public const int TMC_MST_EZ 		=			0x000000200; // EZ �Է� ��ȣ ����
    public const int TMC_MST_CLR  		=			0x000000400; // CLR �Է� ��ȣ ����
    public const int TMC_MST_LTC  		=			0x000000800; // LATCH �Է� ��ȣ ����
    public const int TMC_MST_SD   		=			0x000001000; // SLOW DOWN �Է� ��ȣ ����
    public const int TMC_MST_INP 		=			0x000002000; // IN-POSITION �Է� ��ȣ ����
    public const int TMC_MST_SVON       =           0x000004000; //SVON ��ȣ ����
    public const int TMC_MST_ARST       =           0x000008000; //SERVO ALARM RESET ��ȣ ����
    public const int TMC_MST_STA  		=			0x000010000; // STA �Է� ��ȣ ����
    public const int TMC_MST_STP  		=			0x000020000; // STP �Է� ��ȣ ����
    public const int TMC_MST_SYNC  		=			0x000040000; // SYNC ���� �Է� ��ȣ ����
    public const int TMC_MST_GANT  		=			0x000080000; // GANTRY ���� ���� �Է� ��ȣ ����

    public const int  TMC_DRV_STOP 		=			0x00000001; // ��� ���� ��
    public const int  TMC_WAIT_DR 		=			0x00000002; // DR �Է� ��ȣ ��ٸ�
    public const int  TMC_WAIT_STA 		=			0x00000004; // STA �Է� ��ȣ ��ٸ�
    public const int  TMC_WAIT_INSYNC 	=			0x00000008; // ���� ���� ��ȣ ��ٸ�
    public const int  TMC_WAIT_OTHER 	=			0x00000010; // Ÿ�� ���� ��ȣ ��ٸ�
    public const int  TMC_WAIT_CRC 		=			0x00000020; // CRC ��� �Ϸ� ��ٸ�
    public const int  TMC_WAIT_DIR 		=			0x00000040; // ���� ��ȭ�� ��ٸ�
    public const int  TMC_BACKLASH 		=			0x00000080; // BACKLASH ����
    public const int  TMC_WAIT_PE 		=			0x00000100; // PA/PB �Է� ��ȣ ��ٸ�
    public const int  TMC_IN_FA 		=			0x00000200; // FA ���� ���� �� ( Ȩ ����� �ӵ� )
    public const int  TMC_IN_FL 		=			0x00000400; // FL ���� ���� ��
    public const int  TMC_IN_FUR 		=			0x00000800; // ���� ��
    public const int  TMC_IN_FH 		=			0x00001000; // FH ���� ���� �� 
    public const int  TMC_IN_FDR 		=			0x00002000; // ���� �� 
    public const int  TMC_WAIT_INP 		=			0x00004000; // INP �Է� ��ȣ ��ٸ�
    public const int  TMC_IN_CMP 		=			0x00008000; // CMP ������
    public const int  TMC_WAIT_SYNC 	=			0x00010000; // SYNC �Է� ��ȣ ��ٸ�
    public const int  TMC_WAIT_GANT     =           0x00020000; // GANT �Է� ��ȣ ��ٸ�

    // LEVEL type definition //
    public const int TMC_LOGIC_A =					0; 
    public const int TMC_LOGIC_B =					1;

    public const int TMC_LEVEL_LOW =                0;
    public const int TMC_LEVEL_HIGH =               1;

    // stp stop type definition //
    public const int TMC_STP_NSTOP =				0; 
    public const int TMC_STP_ESTOP =				1; 
    public const int TMC_STP_SSTOP =				2; 


    // stop type definition //
    public const int TMC_ESTOP =					0;
    public const int TMC_SSTOP =					1; 

    //soft limit action
    public const int TMC_SOFT_NONE 	=				0; 
    public const int TMC_SOFT_ESTOP =				1; 
    public const int TMC_SOFT_SSTOP =				2; 
    public const int TMC_SOFT_CHVEL =				3; 

    // remain pulse stop type definition //
    public const int TMC_AUTO 	=					0;
    public const int TMC_MANUAL =					1;

    public const int TMC_SD_SLOW =					0; 
    public const int TMC_SD_STOP =					1;	

    // 
    public const int TMC_ERR_NONE 	=				0; /*������� ����*/ 
    public const int TMC_ERR_ESTOP 	=				1; /*��   ����*/
    public const int TMC_ERR_SSTOP 	=				2; /*���� ����*/
    public const int TMC_ERR_CHGVEL	=				3; /*�ӵ� ����*/

    // Encoder input mode definition //
    public const int TMC_EAB1X 	=				    0x00;
    public const int TMC_EAB2X 	=				    0x01;
    public const int TMC_EAB4X 	=				    0x02; 
    public const int TMC_CWCCW 	=				    0x03; 

    //  PA/PB input mode definition //
    public const int TMC_PAB1X 	=				    0x00;
    public const int TMC_PAB2X 	=				    0x01;
    public const int TMC_PAB4X 	=				    0x02;
    public const int TMC_PCWCCW =					0x03;

    // Command output mode definition //
    public const int TMC_ONE_LOW_HIGH_LOW 	=		0x00;
    public const int TMC_ONE_HIGH_HIGH_LOW 	=		0x01;
    public const int TMC_ONE_LOW_LOW_HIGH 	=		0x02;
    public const int TMC_ONE_HIGH_LOW_HIGH 	=		0x03;
    public const int TMC_TWO_CW_CCW_LOW 	=		0x04;
    public const int TMC_TWO_CW_CCW_HIGH 	=		0x05;
    public const int TMC_TWO_CCW_CW_LOW 	=		0x06;
    public const int TMC_TWO_CCW_CW_HIGH 	=		0x07;
    public const int TMC_TWO_PHASE 			=		0x08;
    public const int TMC_TWO_PHASE_RESERVE  =       0x09; 

    // motion type definition //	
    public const int TMC_STAND 	=					0x00; /*steady*/
    public const int TMC_RUNNING =					0x01; /*running*/

    // motion type definition //	
    public const int TMC_FORWARD =                  0;/*forward*/
    public const int TMC_REVERSE =                  1;/*reversed*/

    public const int TMC_DIR_P =                    0;  //Positive Direction
    public const int TMC_DIR_N =                    1;  //Negative Direction

    // Position Move type definition //
    public const int TMC_INC =                      0;  //Incremental Position 
    public const int TMC_ABS =                      1;  //Absolute Position

    // Arc operation direction //
    public const int TMC_CW =                       0;  //Clockwise Direction  ( Angle Decreases  < 0)
    public const int TMC_CCW =                      1;  //Counter Clockwise Direction ( Angle Increases  > 0)

    // Counter name //
    public const int TMC_COMM	=				    0; /*Command*/
    public const int TMC_ACT	=					1; /*Feedback*/
    public const int TMC_DEV	=					2; /*Deviation*/ 
    public const int TMC_GEN	=					3; /*General*/
    public const int TMC_CURVEL	=				    4; /*����ӵ�*/

    // speed profile type definition //
    public const int TMC_PROF_C	=   			    0;   //Constant Speed Profile
    public const int TMC_PROF_T    =                1;  //Trapezoidal Speed Profile
    public const int TMC_PROF_S    =                2;  //S-Curve Speed Profile

    // sta method definition //	
    public const int TMC_STA_SOFTWARE =             0;/*Software */
    public const int TMC_STA_HARDWARE =             1;/* Hardware*/

    // sta action definition //	
    public const int TMC_ACT_LEVEL	=				0;  /* Level Trigger */
    public const int TMC_ACT_FALL	=				1;  /* Edge Trigger*/

    // Compare Method //
    public const int TMC_EQ_PDIR	=				0;  // CmpData = CmpSrc_Value ( while counting up )
    public const int TMC_EQ_NDIR	=				1;  // CmpData = CmpSrc_Value ( while counting down )

    // Compare Type //
    public const int TMC_CMP_IDX0 =                 0;  /*compare[0]*/
    public const int TMC_CMP_IDX1 =                 1;  /*compare[1]*/
    public const int TMC_CMP_IDX2 =                 2;  /*compare[2]*/
    public const int TMC_CMP_IDX3 =                 3;  /*compare[3]*/

    // Gantry Type //
    public const int TMC_GANT_IDX0 =                0;  /*Gantry[0]*/
    public const int TMC_GANT_IDX1 =                1;  /*Gantry[1]*/
    public const int TMC_GANT_IDX2 =                2;  /*Gantry[2]*/
    public const int TMC_GANT_IDX3 =                3;  /*Gantry[3]*/

    // Method when general comparator met the condition //
    public const int TMC_MTH_NONE		=			0;  // ���� ���� ���� ����
    public const int TMC_MTH_EQ_DIR		=		    1;  // Counter ����� ����
    public const int TMC_MTH_EQ_PDIR	=			2;  // Counter Up ��
    public const int TMC_MTH_EQ_NDIR	=			3;  // Counter Down ��

    // Action when general comparator met the condition //
    public const int TMC_EVT_ONLY	=				0;  // ���ͷ�Ʈ�� �߻�
    public const int TMC_EVT_ESTOP	=				1;  // ���ͷ�Ʈ �� �� ����
    public const int TMC_EVT_STOP	=				2;  // ���ͷ�Ʈ �� ������ ����
    public const int TMC_EVT_SPDCHG	=			    3;  // ���ͷ�Ʈ �� �ӵ�����


    // Backlash/Slip correction mode //
    public const int  TMC_CORR_DIS	=				0; // Disable correction 
    public const int  TMC_CORR_BACK	=			    1; // Backlash correction mode 
    public const int  TMC_CORR_SLIP	=			    2; // Slip correction mode

    //position trigger output level
    public const int  TMC_RISING	=				0;
    public const int  TMC_FALLING	=				1;

    // Interrupt Handler Type //
    public const int  TMC_IHT_MESSAGE	=			0;
    public const int  TMC_IHT_CALLBACK	=			1;
    public const int  TMC_IHT_EVENT =			    2;

    // SetFilterAB�� ��� //
    public const int  TMC_ENC_AB	=			    0;
    public const int  TMC_PULSAR_AB	=		        1;

    public const int  TMC_HOME_POS_RST0	=	        0; 	// ORG(/EL/EZ) ��ȣ�� �߻��� �� COMMAND & FEEDBACK ��ġ�� 0���� Ŭ�����Ѵ�.
    public const int  TMC_HOME_POS_RST1	=		    1;	// �������͸� ��� �Ϸ��ϰ� ���� COMMAND & FEEDBACK ��ġ�� ��� 0���� Ŭ�����Ѵ�.
    public const int  TMC_HOME_POS_RST2	=		    2;	// �������͸� ��� �Ϸ��ϰ� ���� FEEDBACK ��ġ�� �״�� �ΰ� COMMAND ��ġ�� FEEDBACK ��ġ�� ��ġ��Ų��.

    // Sync mode //
    public const int  TMC_SYNC_DISABLE    =         0;
    public const int  TMC_SYNC_INT_SYNC   =         1;
    public const int  TMC_SYNC_OTHER_STOP =         2;

    // Internal sync. conditions //
    public const int  TMC_ISYNC_ACC_STA	=		    0;	// 0: at start of acceleration
    public const int  TMC_ISYNC_ACC_END	=		    1;	// 1: at end of acceleration
    public const int  TMC_ISYNC_DEC_STA	=		    2;	// 2: at start of deceleration
    public const int  TMC_ISYNC_DEC_END	=		    3;	// 3: at end of deceleration
    public const int  TMC_ISYNC_SLN		=		    4;	// 4: when (-)software limit met
    public const int  TMC_ISYNC_SLP		=		    5;	// 5: when (+)software limit met
    public const int  TMC_ISYNC_GCMP	=			6;	// 6: when General Comparator condition is satisfied
    public const int  TMC_ISYNC_TCMP	=			7;	// 7: when Trigger Comparator condition is satisfied
    
    //Common
    public const int TMC_MAX_CS =                   4; //Maximum Number of Coordinate Systems

    //Coordinate System No.
    public const int TMC_CS0 =                      0;
    public const int TMC_CS1 =                      1;
    public const int TMC_CS2 =                      2;
    public const int TMC_CS3 =                      3;

    //Coordinate System Mask
    public const int TMC_CS0_MASK =                 0x00000001;
    public const int TMC_CS1_MASK =                 0x00000002;
    public const int TMC_CS2_MASK =                 0x00000004;
    public const int TMC_CS3_MASK =                 0x00000008;
    public const int TMC_CS4_MASK =                 0x00000010;
    public const int TMC_CS5_MASK =                 0x00000020;
    public const int TMC_CS6_MASK =                 0x00000040;
    public const int TMC_CS7_MASK =                 0x00000080;
    public const int TMC_CS8_MASK =                 0x00000100;
    public const int TMC_CS9_MASK =                 0x00000200;
    public const int TMC_CSA_MASK =                 0x00000400;
    public const int TMC_CSB_MASK =                 0x00000800;
    public const int TMC_CSC_MASK =                 0x00001000;
    public const int TMC_CSD_MASK =                 0x00002000;
    public const int TMC_CSE_MASK =                 0x00004000;
    public const int TMC_CSF_MASK =                 0x00008000;

    // Internal sync. conditions //
    public const int  TMC_CNS_VECTOR    =           0;   //0:Vector Vel
    public const int  TMC_CNS_MASTER	=           1;   //1:Long Axis Vel

   // Function Log Level //
    public const int  TMC_DLOG_LEVEL0 =			 0;   //LOG ��� ���� ����
    public const int  TMC_DLOG_LEVEL1 =		     1;   //������ �߻��� ��� 
    public const int  TMC_DLOG_LEVEL2 =		     2;   //��� ���� �Լ� + ���� �Լ�(SET)  
    public const int  TMC_DLOG_LEVEL3 =		     3;   //LEVEL 2 + ��ȯ �Լ�(SET) + ������ ��� �Լ�(DO)
    public const int  TMC_DLOG_LEVEL4 =		     4;   //LEVEL 3 + ������ �Է� �Լ�(DI) 
    public const int  TMC_DLOG_LEVEL5  =         5;   //����

    public const int  TMC_COMM_SPEED2_5	=	        0;  // 2.5Mbps ��� �ӵ�  
    public const int  TMC_COMM_SPEED5 =		        1;  // 5Mbps   ��� �ӵ�   
    public const int  TMC_COMM_SPEED10 =		    2;  // 10Mbps  ��� �ӵ�  
    public const int  TMC_COMM_SPEED20 =		    3;  // 25Mbps  ��� �ӵ�

    //�����̺� �߿��� SB-MN16GPIO-M ��ǰ 
    public const int  TMC_NONE_DIO =                0;   //  ��� ����
    public const int  TMC_ONLY_DI =                 1;   //  �Է� ���� 
    public const int  TMC_ONLY_DO =                 2;   //  ��� ����


    /* Error code (Return code) */ 
    public const int TMC_RV_OK	=					1;   //����

    public const int TMC_RV_MOT_DEVICE_ERR =              -1;     //����̽� ��ȣ ���� ����
    //MCK Error (100 ~ )
    public const int TMC_RV_MOT_INIT_ERR = 		        -100;   //���̺귯�� �ʱ�ȭ ����
    public const int TMC_RV_MOT_FILE_SAVE_ERR =         -101;   //��� �������� �����ϴ� ���� ���忡 ������
    public const int TMC_RV_MOT_FILE_LOAD_ERR =         -102;   //��� �������� ����� ������ �ε尡 �ȵ�

    //MC Error (200 ~ )
    public const int TMC_RV_STOP_P_S_END_ERR =          -200;  //(+) ���� ����Ʈ���� ����Ʈ�� ���� ����
    public const int TMC_RV_STOP_N_S_END_ERR =          -201;  //(-) ���� ����Ʈ���� ����Ʈ�� ���� ����
    public const int TMC_RV_STOP_CMP3_ERR = 		    -202;  //CMP3 �� ���� ����
    public const int TMC_RV_STOP_CMP4_ERR = 		    -203;  //CMP4 �� ���� ����
    public const int TMC_RV_STOP_CMP5_ERR = 		    -204;  //CMP5 �� ���� ����
    public const int TMC_RV_STOP_P_H_END_ERR =          -205;  //(+) ���� �ϵ���� ����Ʈ�� ���� ����
    public const int TMC_RV_STOP_N_H_END_ERR =          -206;  //(-) ���� �ϵ���� ����Ʈ�� ���� ���� 
    public const int TMC_RV_STOP_ALM_ERR =              -207;  //���� �˶��� ���� ����
    public const int TMC_RV_STOP_CSTP_ERR =             -208;  //CSTP ��ȣ�� ���� ����
    public const int TMC_RV_STOP_EMG_ERR =              -209;  //��� ���� ��ȣ�� ���� ����
    public const int TMC_RV_STOP_ESSD_ERR = 		    -210;  //SD �Է� ON �� ���� ����
    public const int TMC_RV_STOP_ESDT_ERR =             -211;  //���� ���� DATA �̻� ���� ����
    public const int TMC_RV_STOP_ESIP_ERR =             -212;  //���� ���� �߿� Ÿ���� �̻� ���� ����
    public const int TMC_RV_STOP_ESPO_ERR =             -213;  //PA/PB �Է¿� ���� �� �����÷ο� �߻��� ���� ����
    public const int TMC_RV_STOP_ESAO_ERR =             -214;  //���� ���� �� ��ġ������ ī������ ī���� ���� OVER �߻��� ���� ����
    public const int TMC_RV_STOP_ESEE_ERR =             -215;  //EA/EB �Է� ERROR �߻� ��(���� ���� ����)
    public const int TMC_RV_STOP_ESPE_ERR =             -216;  //PA/PB �Է� ERROR �߻� ��(���� ���� ����)
    public const int TMC_RV_STOP_SYNC_ERR =             -217;  //SYNC ���� �߿� ������ ��� ���� �� ���� ����
    public const int TMC_RV_STOP_GANT_ERR =             -218;  //GANT ���� �߿� ������ ��� ���� �� ���� ����


    //MAPI Error (1000 ~ ) 
    public const int TMC_RV_DRV_VER_ERR =               -1000;
    public const int TMC_RV_LOC_MEM_ERR =               -1001;    //�޸� ���� ���� ����
    public const int TMC_RV_GLB_MEM_ERR =               -1002;    //���� �޸� ���� ���� ����
    public const int TMC_RV_HANDLE_ERR =                -1003;    //����̽� �ڵ鰪�� ����
    public const int TMC_RV_CREATE_KERNEL_ERR =         -1004;    // Ŀ�� ����̺� ���� ����
    public const int TMC_RV_CREATE_THREAD_ERR =         -1005;    //������ ���� ����
    public const int TMC_RV_CREATE_EVENT_ERR =          -1006;    //�̺�Ʈ ���� ����
    public const int TMC_RV_CREATE_FILE_ERR = 	        -1007;    //���� ���� ����

    //Controller Error (1030 ~ )
    public const int TMC_RV_CON_NOT_FOUND_ERR = 	    -1030;  //CONTROLLER NOT FOUND ����
    public const int TMC_RV_CON_NOT_LOAD_ERR = 			-1031;  //CONTROLLER LOAD ����
    public const int TMC_RV_CON_DIP_SW_ERR = 			-1032;  //���� ID ���� ����
    public const int TMC_RV_CON_MAX_ERR = 				-1033;   // CONTROLLER �ִ� ���� ����
    public const int TMC_RV_PCI_BUS_LINE_ERR = 			-1034;   //PCI ���� ����Ÿ�� �̻��մϴ�.
    public const int TMC_RV_MOD_POS_ERR = 			    -1035;   //��� ������ �߸��Ǿ����ϴ�.
    public const int TMC_RV_SUPPORT_PROCESS =           -1036;   // �������� ���� ���μ���
    public const int TMC_RV_SUPPORT_FUCTION_ERR =       -1037;   // �������� ���� �Լ�
    public const int TMC_RV_CON_OPEN_MODE_ERR =         -1038;   // ����/�ڵ� ��尡 Ʋ��
    public const int TMC_RV_CON_MODEL_TYPE_ERR =        -1039;   // ����� �𵨸��� Ʋ��
    public const int TMC_RV_SUPPORT_HARDWARE_ERR =      -1040;   // �������� ���� �ϵ����

    //Register Error (1050 ~ )
    public const int TMC_RV_PRM_LOAD_ERR =              -1050;  //�Ķ���� �ε� ����
    public const int TMC_RV_PRM_VAL_ERR =               -1051;  //�Ķ���� �� ����
    public const int TMC_RV_PRM_FILENAME_ERR =          -1052;  //�Ķ���� ������ �������� ����
    public const int TMC_RV_PRM_FILENAME_DIFF_ERR =     -1053;  //�̹� ���µ� �Ķ���� ���ϰ� �������� ���� 
    public const int TMC_RV_PRM_OPEN_FILENAME_ERR =     -1054;  //�̹� ���µ� �Ķ���� ������ ����

    //Function Error (1100 ~ )
    public const int TMC_RV_NOT_SPT_ERR =               -1100; // �𵨿��� �������� �ʴ� ���
    public const int TMC_RV_DIV_BY_ZERO_ERR =           -1101; // DIVIDE BY ZERO ����
    public const int TMC_RV_TIME_OUT_ERR =              -1102; // TIME OUT ����
    public const int TMC_RV_WM_QUIT_ERR =               -1103; // WM_QUIT �߻� ����
    public const int TMC_RV_HEL_COORD_NO_ERR =          -1110; // HEL COORDINATE ��ȣ ����
    public const int TMC_RV_CS_COORD_POS_ERR =          -1111; // COORDINATE ��ǥ �̻� ����
    public const int TMC_RV_CON_NO_ERR =                -1120; // �ش� ī���ȣ�� �������� ����
    public const int TMC_RV_AXIS_NO_ERR =               -1121; // �� ��ȣ ����
    public const int TMC_RV_MASTER_AXIS_NO_ERR =        -1122; // �������� ��ȣ ���� 
    public const int TMC_RV_SLAVE_AXIS_NO_ERR =         -1123; // �����̺��� ��ȣ ����
    public const int TMC_RV_COORD_NO_ERR =              -1124; // COORDINATE ��ȣ ����
    public const int TMC_RV_ARG_RNG_ERR =               -1125; // �Լ� ���� ���� ����
    public const int TMC_RV_CS_AXIS_ERR =               -1126; // COORDINATE AXIS ����
    public const int TMC_RV_INT_CFG_ERR =               -1127; // ���ͷ�Ʈ ���� ����
    public const int TMC_RV_COORD_AXES_ERR =            -1128; // COORDINATE AXIS ���� ����
    public const int TMC_RV_CONT_AXES_ERR =             -1129; // ���� ���  AXIS ���� ����


    public const int TMC_RV_GROUP_RNG_ERR =             -1130; // Group ���� ����
    public const int TMC_RV_AXES_MIN_ERR =              -1131; // AXIS �ּ� ���� ����
    public const int TMC_RV_AXES_MAX_ERR =              -1132; // AXIS �ִ� ����  ����
    /////////////////////////////////////////////////////////////////

    public const int TMC_RV_MTN_IN_STOP_ERR =           -1140;  // ��� �������̾�� �Ǵµ� ��� �������� �ƴ� �� ����
    public const int TMC_RV_MTN_DRV_ERR =               -1141;  // ��� �������̾�� �Ǵµ� ��� ������ �� �� ����
    public const int TMC_RV_HOME_BUSY_ERR =             -1142;  // ORG SEARCH ���� ����
    public const int TMC_RV_DRV_STEADY_ERR =            -1143;  // ���� ����
    public const int TMC_RV_DRV_PAB_ERR	=		        -1144;  // �����޽� �������϶� ��� ��� ���� �� ����
    public const int TMC_RV_DRV_MODIFY_POS_ERR =        -1145;  // ��� ������ �߻� �Ǵ� �̹� �̼��� �Ϸ�Ǿ� ��ġ �������̵尡 ������� ����
    public const int TMC_RV_PRE_POS_ERR =      	        -1146;  // �������� ����Ÿ ����
    public const int TMC_RV_PRE_FULL_ERR =              -1147;  // �������� ����Ÿ Ǯ ���� ����

    public const int TMC_RV_MIN_VEL_ERR = 		        -1150;   //  MIN VEL VALUE IS UNDER VALID 
    public const int TMC_RV_MAX_VEL_ERR = 	            -1151;   //  MAX VEL VALUE IS OVER VALID 
    public const int TMC_RV_MIN_STARTV_ERR =            -1152;   //  START VEL VALUE IS UNDER VALID SV
    public const int TMC_RV_MAX_STARTV_ERR =            -1153;   //  START VEL VALUE IS OVER VALID SV
    public const int TMC_RV_MIN_WORKV_ERR =             -1154;   //  WORK  VEL VALUE IS UNDER VALID WV
    public const int TMC_RV_MAX_WORKV_ERR =             -1155;   //  WORK  VEL IS OVER VALID WV
    public const int TMC_RV_MIN_ACC_ERR =               -1156;   //  ACC TIME IS UNDER VALID AC
    public const int TMC_RV_MAX_ACC_ERR =               -1157;   //  ACC TIME IS OVER VALID AC
    public const int TMC_RV_MIN_DEC_ERR =               -1158;   //  DEC TIME IS UNDER VALID AC
    public const int TMC_RV_MAX_DEC_ERR =               -1159;   //  DEC TIME IS OVER VALID AC

    public const int TMC_RV_MIN_DISTANCE_ERR =          -1160;   //  �̵� �Ÿ��� �ּҰ� �̻�
    public const int TMC_RV_MAX_DISTANCE_ERR =          -1161;   //  �̵� �Ÿ��� �ִ밪 �̻�

    public const int TMC_RV_DLOG_ERR =                  -1180;   // FUNCTION �α� ����
    public const int TMC_RV_DLOG_LEVEL_ERR =            -1181;   // FUNCTION �α� ���� ����
    public const int TMC_RV_DLOG_FILENAME_ERR =         -1182;   // FUNCTION �α� ���� ����

    public const int TMC_RV_CMP_CONNECT_ERR =           -1200;   //CMP ���� ���� ����

    /////////////////////////////////////////////////////////////////
    public const int TMC_RV_STATION_COMMUNICATION_ERR = -2000;   //�����̺� ���� ����
    public const int TMC_RV_STATION_INFO_ERR =          -2001;   //�����̺� ���� ȹ�� ����
    public const int TMC_RV_CONNECT_CYCLIC_ERR =	    -2002;   //����Ŭ�� ��� ���� ���� �Ǵ� Off ����
    public const int TMC_RV_STATION_NO_ERR =		    -2003;   //�����̺� ��ȣ ����
    public const int TMC_RV_CONNECT_SYS_ERR	=		    -2004;   //�ý��� ��� ���� ����	// Gee 2014.08.19
    public const int TMC_RV_COMM_RESET_ERR =		    -2005;   //��� ��� ���� ����		// Gee 2014.08.19
    public const int TMC_RV_SLAVE_ZERO_ERR =		    -2006;   //����ϴ� �����̺갡 0���� ����Ŭ�� ��� ����	// Gee 2014.08.19
    public const int TMC_RV_GPIO_ERR =	    			-2007;   //GPIO �������� �������� �ʴ� �Լ� ����
    public const int TMC_RV_DATA_TX_ERR =  			    -2008;   //������ ��� ���� ����
    public const int TMC_RV_TX_CLR_ERR =   		        -2009;   //����ó�� �Ϸ� ���ͷ�Ʈ Ŭ���� ����
    public const int TMC_RV_STATION_TYPE_ERR = 		    -2010;   //�����̺� ����� ������ �Լ��� ���� ����
    public const int TMC_RV_MULTI_AXIS_ERR	=   	    -2011;   //��Ƽ���곪 ���� �̼۽� ���� �����̺� ���� ���� �ƴ�
    public const int TMC_RV_CYCLIC_COMM_ERR =			-2012;   //����Ŭ�� ��� �� ��� ���� �߻�
    public const int TMC_RV_CONFIG_MISMATCHING_ERR =    -2013;   //���� �����̺� ��� ������ ����� ������ ��ġ���� ����
    public const int TMC_RV_SYSCOMM_BEGIN_ERR =         -2014;   //����Ŭ�� ��� ���ε� �����̺� ��� ���� ���� ���� ����
    public const int TMC_RV_DATA_RX_ERR =  			    -2015;   //������ ��� ���� ����
    public const int TMC_RV_TX_CYCLIC_ERR =             -2016;   //Cyclic ��� ������ ������ ���� ����
    public const int TMC_RV_TX_CPU_ACCESS_ERR =         -2017;   //�����̺� CPU ������ ������ ���� ����
    public const int TMC_RV_TX_STATION_RECEIVE_ERR =    -2018;   //�����̺� ���� ������ ������ ���� ����
    public const int TMC_RV_SLAVE_POWER_OFF_ON_ERR =    -2019;   //�����̺� ������ OFF �� �ٽ� ������ ON ����

    public const int TMC_RV_UNKNOWN_ERR =               -9999;  // �˼� ���� ����


   
}
//===========================================================================
// End of file.
//===========================================================================

