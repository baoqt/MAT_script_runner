% T'ena Sensor Block Task
% DESIGNED BY CML

function TenaSensor2_BlockTask_ViconData_auto (inputPath, outputPath, fileName, trial, plotMode)

%Load in files
data = csvread(strcat(inputPath, fileName, sprintf("_%03d", trial), '.csv'), 5, 2);

%Butterworth Filter!
[b,a]=butter(6,0.05); %[b,a] = butter(n, Wn) where n = order and Wn is the cutoff fq, normalized by 2pi fs
%for fc = 5Hz, we have that Wn = 5(2pi)/2pifs = 5/100 = 0.05
mkr_F=filtfilt(b,a,data);

%assign columns to data
x = data(:,1);
y = data(:,2);
z = data(:,3);

%--------------------------- Calculate Velocity ----------------------------
vx = centdiff(x);
vy = centdiff(y);
vz = centdiff(z);
vr = sqrt((vx.^2)+(vy.^2)+(vz.^2));

%Plot Position and Velocity (wmc)
% if (plotMode == 1)
%     figure; subplot (2,1,1);
%     plot(vx,'k'); hold on; plot (vy,'b'); hold on; plot (vz,'r'); hold on; title('Velocity (wmc)')
%     legend('x','y','z')
% 
%     hold on; subplot (2,1,2); 
% 
%     plot (vr,'linewidth',2); hold on;
% end

[maxtab_vr, mintab_vr] = peakdet(vr, 2); %Detect Peaks in Time Series (wmc)

%if (plotMode == 1)
%    plot(maxtab_vr(:,1), maxtab_vr(:,2), 'r*'); hold on; title('Resultant Velocity'); hold on;
%end
%--------------------------- Calculate Onset ----------------------------
for onset_vr = maxtab_vr(1,1):-1:1
                if vr(onset_vr)<maxtab_vr(2,2)*0.015;
                    break
                end
end


%Determine Offset
for offset_vr = (maxtab_vr(size(maxtab_vr, 1),1):1:length(vr)-1)
                if vr(offset_vr)< maxtab_vr(size(maxtab_vr, 2),2)*0.015;
                    break
                end
 end


% plot(onset_vr, vr(onset_vr), 'r*'); plot(offset_vr, vr(offset_vr), 'r*');
% legend('VR', 'VR Peaks' , 'VR Onset', 'VR Offset');
          
%--------------------------- Trim Time Series ----------------------------
trim = vr(onset_vr:offset_vr);

trimvx = vx(onset_vr:offset_vr);
trimvy = vy(onset_vr:offset_vr);
trimvz = vz(onset_vr:offset_vr);

if (plotMode == 1)
    f70 = figure(70);
    f70.Name = strcat("Trial ", int2str(trial), ": Trimmed Resultant Data");
    hold on; plot(trim,'b','linewidth',2)
    title('Vicon Resultant Velocity');
    legend("IMU", "Vicon");
end

%--------------------------- Calculate Kinematics ----------------------------
% trimvrx = trimvx(onset_vr:offset_vr);
% trimvry = trimvy(onset_vr:offset_vr);
% trimvrz = trimvz(onset_vr:offset_vr);

% Movement Time: %100 Hz = 10, as value depends on sampling rate
mt_v = (offset_vr - onset_vr)*10;

%Peak Velocity and Time to Peak Velocity
[peakvel,tpeakvel] = max(trim);

pv_v = peakvel;
tpv_v = tpeakvel;

%Mean Velocity
meanv_v = mean(trim);

%Movement Smoothness
sal_v = func_SAL(trimvx, trimvy, trimvz);
[jerk_dim,jerk_dim_log] = func_jerk_dim(trimvx, trimvy, trimvz);

%Path Length
format shortG
pl_v = trapz(trim);

% Number of peaks > .2
np_v = length(maxtab_vr);

% Add variables into matrix, then save
outcome = [mt_v, pv_v, tpv_v, meanv_v, pl_v, sal_v, np_v];
csvwrite(strcat(outputPath, fileName, sprintf("_%03d", trial), '.csv'), outcome);
csvwrite(strcat(outputPath, '\Velocity_', fileName, sprintf("_%03d", trial), '.csv'), trim);
