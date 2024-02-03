import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Form, InputNumber, Typography, Space, Button, notification } from 'antd';
import { getSignalById, createSignal } from '../../../services/signal.service';
  

const CreateSignalForm = () => {
  const [file, setFile] = useState(null);
  const [loading, setLoading] = useState(false);
  const navigate = useNavigate();

  const formItemLayout = {
    labelCol: {
      xs: {
        span: 24,
      },
      sm: {
        span: 16,
      },
    },
    wrapperCol: {
      xs: {
        span: 16,
      },
      sm: {
        span: 14,
      },
    },
  };
  
  const handleCreateSignal = async (signalRequest) => {
    try {
      const signal = await createSignal(signalRequest);
      const responseGet = await getSignalById(signal.id);

      const blob = await responseGet.blob();
      const url = URL.createObjectURL(blob);
      const filename = `signal_image_${signal.id}.jpeg`;

      setFile({ filename, url});

      setLoading(false);
      navigate('/');
      notification.success({
        message: 'Подтверждение',
        description: 'Запрос успешно обработан!',
        placement: 'bottomRight'
      });
    } catch (err) {

      notification.error({
        message: 'Ошибка',
        description: 'Непредвиденная ошибка. Пожалуйста, попробуйте позже',
      });
    } 
  }  

  const onFinish = async (values) => {
    setLoading(true)
    const signalRequest = {
      amplitude: values.Amplitude,
      samplingFrequency: values.SamplingFrequency,
      signalFrequency: values.SignalFrequency,
      periodValue: values.PeriodValue
    };
 
    await handleCreateSignal(signalRequest);
  };

  return (
    <>

      {
        loading ? 
          <h2 style={{ textAlign: 'center' }} >Wait for a second...</h2>
        :
        <div style={{ maxWidth: 600, margin: 'auto', textAlign: 'center', position: 'relative' }}>
          {file && (
            <a href={file.url} download={file.filename} style={{ display: 'none' }} ref={(el) => el && el.click()}></a>
          )}
          <Form
            onFinish={(onFinish)}
            {...formItemLayout}
            variant="filled"
            style={{
              maxWidth: 600,
            }}
            labelAlign="top"
          >
            <Space size="middle">
              <Typography.Title level={3}>Формирование графика</Typography.Title>
            </Space>

              <Form.Item
                label="Амплитуда - A"
                name="Amplitude"
                rules={[
                  {
                    required: true,
                    message: 'Введите значение амплитуды',
                  },
                ]}
              >
                <InputNumber />
              </Form.Item>

              <Form.Item
                label="Частота дискретизации сигнала - F(d)"
                name="SamplingFrequency"
                rules={[
                  {
                    required: true,
                    message: 'Введите значение частоты дискретизации сигнала в точках за секунду',
                  },
                ]}
              >
                <InputNumber/>
              </Form.Item>

              <Form.Item
                label="Частота сигнала в герцах - F(s)"
                name="SignalFrequency"
                rules={[
                  {
                    required: true,
                    message: 'Введите значение частоты сигнала в герцах',
                  },
                ]}
              >
                <InputNumber/>
              </Form.Item>

              <Form.Item
                label="Количество периодов (n)"
                name="PeriodValue"
                rules={[
                  {
                    required: true,
                    message: 'Введите кол-во периодов',
                  },
                ]}
              >
                <InputNumber/>
              </Form.Item>
              <Button 
              style={{ marginLeft: 'auto', backgroundColor: 'rgb(31, 136, 61)' }}
              type= 'primary' 
              htmlType= 'submit'>
                Сформировать график
              </Button> 
          </Form>
        </div>
      }
    </>
  );
}

export default CreateSignalForm;

