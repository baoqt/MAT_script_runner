% T'ena Sensor Block Task
% DESIGNED BY CML

clear; clc

%Load in files
filename = 'C:\Users\cmhughes\Documents\MATLAB\vicon_tube\vicon_tube_49.csv';
data_raw = load(filename);  
data = data_raw(:,1:3);

%Butterworth Filter!
[b,a]=butter(6,0.05); %[b,a] = butter(n, Wn) where n = order and Wn is the cutoff fq, normalized by 2pi fs
%for fc = 5Hz, we have that Wn = 5(2pi)/2pifs = 5/100 = 0.05
mkr_F=filtfilt(b,a,data);

%assign columns to data
x = data(:,1);
y = data(:,2);
z = data(:,3);


%--------------------------- Calculate Velocivelwristxty ----------------------------
vx = centdiff(x);
vy = centdiff(y);
vz = centdiff(z);
vr = sqrt((vx.^2)+(vy.^2)+(vz.^2));

%Plot Position and Velocity (wmc)
figure; subplot (2,1,1);
plot(vx,'k'); hold on; plot (vy,'b'); hold on; plot (vz,'r'); hold on; title('Velocity (wmc)')
legend('x','y','z')

hold on; subplot (2,1,2); 

plot (vr,'linewidth',2); hold on;

[maxtab_vr, mintab_vr] = peakdet(vr, 2); %Detect Peaks in Time Series (wmc)
plot(maxtab_vr(:,1), maxtab_vr(:,2), 'r*'); hold on; title('Resultant Velocity'); hold on;

%--------------------------- Calculate Onset ----------------------------
MinDuration = 50;

if any(vr(maxtab_vr(1,1):-1:1)<maxtab_vr(1,2)*0.01)
        for onset_vr = maxtab_vr(1,1):-1:1
            
            if onset_vr - MinDuration > 1
                minZeroVelocityFrom =  onset_vr - MinDuration;
            else
                minZeroVelocityFrom = 1;
            end   
            
            if (vr(onset_vr)<maxtab_vr(1,2)*0.01 ) && (mean(vr(minZeroVelocityFrom:onset_vr))<0.05)
                break
            end
        end
    else
        for onset_vr = maxtab_vr(1,1):-1:1
            
            if onset_vr - MinDuration > 1
                minZeroVelocityFrom =  onset_vr - MinDuration;
            else
                minZeroVelocityFrom = 1;
            end

            
            if (vr(onset_vr)< maxtab_vr(1,2)*0.05) && (mean(vr(minZeroVelocityFrom:onset_vr))<0.1)
                break
            end
        end
end
   
    %--------------------------- Calculate Offset ----------------------------
   MinDuration = 75;
   sizeMaxtab = size(maxtab_vr);
        
   if any(vr(maxtab_vr(sizeMaxtab(1),1):1:end)<maxtab_vr(sizeMaxtab(1),2)*0.01)
    for offset_vr = (maxtab_vr(sizeMaxtab(1),1):1:length(vr)-1)

        if offset_vr + MinDuration < length(vr)
            minZeroVelocityUntil =  offset_vr + MinDuration;
        else
            minZeroVelocityUntil = length(vr);
        end

        if (vr(offset_vr)< maxtab_vr(sizeMaxtab(1),2)*0.01) || ((mean(vr(offset_vr:minZeroVelocityUntil))<0.02) && (vr(offset_vr)< 0.005))
            break
        end
    end
elseif any(vr(maxtab_vr(sizeMaxtab(1),1):1:size(vr)<maxtab_vr(sizeMaxtab(1),2)*0.05))
    for offset_vr = (maxtab_vr(sizeMaxtab(1),1):1:length(vr)-1)

        if offset_vr + MinDuration < length(vr)
            minZeroVelocityUntil =  offset_vr + MinDuration;
        else
            minZeroVelocityUntil = length(vr);
        end

        if (vr(offset_vr)< maxtab_vr(sizeMaxtab(1),2)*0.05) || ((mean(vr(offset_vr:minZeroVelocityUntil))<0.02) && (vr(offset_vr)< 0.005))
            break
        end
    end
else
    [s, loc_offset_vr] = min(vr(maxtab_vr(sizeMaxtab(1),1):1:length(vr)-1));
    offset_vr = loc_offset_vr + maxtab_vr(sizeMaxtab(1),1) -1;
end

% plot(onset_vr, vr(onset_vr), 'r*'); plot(offset_vr, vr(offset_vr), 'r*');
% legend('VR', 'VR Peaks' , 'VR Onset', 'VR Offset');
          
%--------------------------- Trim Time Series ----------------------------
trim = vr(onset_vr:offset_vr);

trimvrx = vx(onset_vr:offset_vr);
trimvry = vy(onset_vr:offset_vr);
trimvrz = vz(onset_vr:offset_vr);

f70 = figure(70);
f70.Name = 'Trimmed Resultant Data';
hold on; plot(trim,'b','linewidth',2)
title('Vicon Resultant Velocity');

%----------------------------Calculate Kinematic Variables-------------------
mt = (offset_vr - onset_vr);

sal = func_SAL(trimvrx, trimvry, trimvrz);
[jerk_dim,jerk_dim_log] = func_jerk_dim(trimvrx, trimvry, trimvrz);

pv = max(vr);

meanvel = mean(vr(onset_vr:offset_vr));
 
format short

mt
sal
pv
% meanvel
