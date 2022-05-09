clear
clc

data = csvread ('dl003_elbflex_001.csv', 5, 2); 

% %assign columns to data
ASIx = data(end-1,1);
ASIy = data(end-1,2);
ASIz = data(end-1,3);
SHOx = data(end-1,4);
SHOy = data(end-1,5);
SHOz = data(end-1,6);
ELBx = data(end-1,7);
ELBy = data(end-1,8);
ELBz = data(end-1,9);
WRIx = data(end-1,10);
WRIy = data(end-1,11);
WRIz = data(end-1,12);
MCPx = data(end-1,13);
MCPy = data(end-1,14);
MCPz = data(end-1,15);

%%%%%%%%% %Upper Limb: Shoulder
%Lengths
shohip_length = (sqrt(((SHOx - ASIx).^2) + ((SHOz - ASIz).^2)));
shoelb_length = (sqrt(((SHOx - ELBx).^2) + ((SHOz - ELBz).^2)));
showri_length = (sqrt(((SHOx - WRIx).^2) + ((SHOz - WRIz).^2)));
elbwri_length = (sqrt(((ELBx - WRIx).^2) + ((ELBz - WRIz).^2)));
wrimcp_length = (sqrt(((WRIx - MCPx).^2) + ((WRIz - MCPz).^2)));
elbmcp_length = (sqrt(((ELBx - MCPx).^2) + ((ELBz - MCPz).^2)));
elbhip_length = (sqrt(((ELBx - ASIx).^2) + ((ELBz - ASIz).^2))); 

% Shoulder
cSHOa = (shohip_length^2 + shoelb_length^2 - elbhip_length^2)/(2* shohip_length * shoelb_length);
shoulderangle = acos(cSHOa);
thetashoulder = shoulderangle*180/pi;
thetashoulder1 = real(thetashoulder);

% Elbow
cELBa = (shoelb_length^2 + elbwri_length^2 - showri_length^2)/(2* shoelb_length * elbwri_length);
elbowangle = acos(cELBa);
thetaelbow = elbowangle*180/pi;

% Wrist
cWRIa = (wrimcp_length^2 + elbwri_length^2 - elbmcp_length^2)/(2* wrimcp_length * elbwri_length);
wristangle = acos(cWRIa);
thetawrist = wristangle*180/pi;

%%%%%%%%%
%%%%%%%%%

%Y and Z
figure (99)
line ([SHOx,ASIx],[SHOz,ASIz], 'Color','b');
hold on; line([ELBx,WRIx], [ELBz, WRIz], 'Color', 'b');
hold on; line([WRIx,MCPx], [WRIz, MCPz], 'Color', 'b');
hold on;line([SHOx,ELBx], [SHOz, ELBz], 'Color', 'b'); 
text(ASIx, ASIz,'Hip'), 
text(SHOx, SHOz,'Shoulder'), text(ELBx, ELBz,'elbow'), text(WRIx, WRIz,'Wrist'), text(MCPx, MCPz,'Fingers')
plot(SHOx,SHOz,'-o','MarkerSize',8,'MarkerEdgeColor','red','MarkerFaceColor',[1 .6 .6])
plot(ASIx,ASIz,'-o','MarkerSize',8,'MarkerEdgeColor','red','MarkerFaceColor',[1 .6 .6])
plot(ELBx,ELBz,'-o','MarkerSize',8,'MarkerEdgeColor','red','MarkerFaceColor',[1 .6 .6])
plot(WRIx,WRIz,'-o','MarkerSize',8,'MarkerEdgeColor','red','MarkerFaceColor',[1 .6 .6])
plot(MCPx,MCPz,'-o','MarkerSize',8,'MarkerEdgeColor','red','MarkerFaceColor',[1 .6 .6])

fprintf('Shoulder angle is %6.2f degrees \n', thetashoulder)
fprintf('Elbow angle is %6.2f degrees \n', thetaelbow)
fprintf('Wrist angle is %6.2f degrees \n', thetawrist)


% %Get user input to note down in output csv
% prompt = 'What is the subject code? ';
% subnum = input(prompt);
% 
% %Get user input to note down in output csv
% prompt = 'What is the trial number? ';
% trialnum = input(prompt);
% 
% %Get user input to note down in output csv
% prompt = 'What is the joint angle being estimated? ';
% joint = input(prompt);
% 
% %Get user input to note down in output csv
% prompt = 'What is the motion being performed? ';
% motion = input(prompt);

%Add variables into matrix, then save
outcome = {subjectNum, trialNum, jointAngle, motionName, thetashoulder, thetaelbow, thetawrist};
writecell(outcome, strcat(subjectNum, '_', trialNum, '_output.csv'));

end